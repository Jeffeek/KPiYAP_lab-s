#region Using namespaces

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab_no25.Model.Entities;
using Lab_no25.Services.Interfaces.EntityServices;
using Lab_no26plus27.Model.AsyncCommand;
using Lab_no26plus27.ViewModels.EntitiesViewModels;
using Prism.Commands;
using Prism.Mvvm;

#endregion

namespace Lab_no26plus27.ViewModels.TabsViewModels
{
    public class CustomersTabViewModel : BindableBase
    {
        private readonly ICustomersService _customersService;
        private ObservableCollection<CustomerEntityViewModel> _customers;
        private readonly List<CustomerEntityViewModel> _internalList;
        private bool _isEditMode;
        private string _searchText = String.Empty;
        private CustomerEntityViewModel _selectedCustomer;
        private DelegateCommand _addCustomerCommand;
        private DelegateCommand _changeEditModeCommand;
        private DelegateCommand _searchCommand;
        private AsyncRelayCommand _removeCustomerCommand;
        private AsyncRelayCommand _applyCustomerChangesCommand;
        private AsyncRelayCommand _reloadCustomersCommand;

        public CustomersTabViewModel(ICustomersService customersService)
        {
            _customersService = customersService;
            Customers = new ObservableCollection<CustomerEntityViewModel>();
            _internalList = new List<CustomerEntityViewModel>();
            ReloadToysAsync().Wait();
        }

        public DelegateCommand AddCustomerCommand =>
            _addCustomerCommand ??= new DelegateCommand(OnAddToyCommandExecuted);

        public DelegateCommand ChangeEditModeCommand =>
            _changeEditModeCommand ??= new DelegateCommand(OnChangeEditModeCommandExecuted,
                                                           CanManipulateOnCustomer)
                .ObservesProperty(() => SelectedCustomer);

        public DelegateCommand SearchCommand =>
            _searchCommand ??=
                new DelegateCommand(OnSearchCommandExecuted, () => SearchText.Length != 0)
                    .ObservesProperty(() => SearchText);

        public AsyncRelayCommand RemoveCustomerCommand =>
            _removeCustomerCommand ??= new AsyncRelayCommand(OnRemoveToyCommandExecuted,
                                                             CanManipulateOnCustomer);

        public AsyncRelayCommand ApplyCustomerChangesCommand =>
            _applyCustomerChangesCommand ??= new AsyncRelayCommand(OnApplyToyChangesCommandExecuted);

        public AsyncRelayCommand ReloadCustomersCommand =>
            _reloadCustomersCommand ??= new AsyncRelayCommand(ReloadToysAsync);

        public ObservableCollection<CustomerEntityViewModel> Customers
        {
            get => _customers;
            set => SetProperty(ref _customers, value);
        }

        public CustomerEntityViewModel SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                SetProperty(ref _selectedCustomer, value);
                RemoveCustomerCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetProperty(ref _isEditMode, value);
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;

                if (value != String.Empty) return;

                Customers.Clear();
                Customers.AddRange(_internalList);
            }
        }

        private void OnSearchCommandExecuted()
        {
            CustomerEntityViewModel[] filteredToys;
            if (Int32.TryParse(SearchText, out var number))
            {
                filteredToys =
                    _internalList.Where(x => x.Entity.Id == number).ToArray();

                if (filteredToys.Length == 0) return;

                Customers.Clear();
                Customers.AddRange(filteredToys);

                return;
            }

            filteredToys = Customers.Where(x => x.Entity.FullName.Contains(SearchText) || x.Entity.PhoneNumber.Contains(SearchText)).ToArray();
            Customers.Clear();
            Customers.AddRange(filteredToys);
        }

        private bool CanManipulateOnCustomer() => SelectedCustomer is not null;

        private void OnChangeEditModeCommandExecuted() => IsEditMode = !IsEditMode;

        private void OnAddToyCommandExecuted()
        {
            Customers.Insert(0,
                             new CustomerEntityViewModel(new CustomerEntity
                                                         {
                                                             FullName = String.Empty,
                                                             PhoneNumber = "+375"
                                                         }));

            SelectedCustomer = Customers.First();
        }

        private async Task OnRemoveToyCommandExecuted()
        {
            if (SelectedCustomer.Entity.Id == 0) Customers.Remove(SelectedCustomer);
            await _customersService.RemoveCustomerAsync(SelectedCustomer.Entity);
            Customers.Remove(SelectedCustomer);
            SelectedCustomer = null;
        }

        private async Task OnApplyToyChangesCommandExecuted()
        {
            if (SelectedCustomer.Entity.Id == 0)
                await _customersService.AddCustomerAsync(SelectedCustomer.Entity);
            else
                await _customersService.UpdateCustomerAsync(SelectedCustomer.Entity);

            await ReloadToysAsync();
        }

        private async Task ReloadToysAsync()
        {
            var dbCustomers = await _customersService.GetAllCustomersAsync();
            Customers.Clear();
            _internalList.Clear();
            foreach (var customerEntity in dbCustomers)
                _internalList.Add(new CustomerEntityViewModel(customerEntity));

            Customers.AddRange(_internalList);
        }
    }
}