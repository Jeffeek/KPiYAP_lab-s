#region Using namespaces

using System;
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
        private bool _isEditMode;
        private CustomerEntityViewModel _selectedCustomer;

        public CustomersTabViewModel(ICustomersService customersService)
        {
            _customersService = customersService;
            Customers = new ObservableCollection<CustomerEntityViewModel>();
            ChangeEditModeCommand = new DelegateCommand(OnChangeEditModeCommandExecuted, CanManipulateOnCustomer).ObservesProperty(() => SelectedCustomer);
            ApplyCustomerChangesCommand = new AsyncRelayCommand(OnApplyToyChangesCommandExecuted, CanManipulateOnCustomer);
            RemoveCustomerCommand = new AsyncRelayCommand(OnRemoveToyCommandExecuted, CanManipulateOnCustomer);
            AddCustomerCommand = new DelegateCommand(OnAddToyCommandExecuted);
            ReloadCustomersCommand = new AsyncRelayCommand(ReloadToysAsync);
            ReloadToysAsync().Wait();
        }

        public DelegateCommand AddCustomerCommand { get; }

        public AsyncRelayCommand RemoveCustomerCommand { get; }

        public AsyncRelayCommand ApplyCustomerChangesCommand { get; }

        public DelegateCommand ChangeEditModeCommand { get; }

        public AsyncRelayCommand ReloadCustomersCommand { get; }

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
                ApplyCustomerChangesCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetProperty(ref _isEditMode, value);
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
            var customers = await _customersService.GetAllCustomersAsync();
            Customers.Clear();
            foreach (var customer in customers) Customers.Add(new CustomerEntityViewModel(customer));
        }
    }
}