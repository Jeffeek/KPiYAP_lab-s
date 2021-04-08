#region Using namespaces

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Lab_no25.Model.Entities;
using Lab_no25.Services.Interfaces.EntityServices;
using Lab_no26plus27.Model.AsyncCommand;
using Lab_no26plus27.ViewModels.EntitiesViewModels;
using Prism.Commands;
using Prism.Mvvm;

#endregion

namespace Lab_no26plus27.ViewModels.TabsViewModels
{
    public class PreOrdersTabViewModel : BindableBase
    {
        public EventHandler<PreOrderEntityViewModel> FoundToyForPreOrder;
        private readonly IPreOrdersService _preOrdersService;
        private bool _isEditMode;
        private ObservableCollection<PreOrderEntityViewModel> _preOrders;
        private PreOrderEntityViewModel _selectedPreOrder;
        private DelegateCommand _addPreOrderCommand;
        private AsyncRelayCommand _removePreOrderCommand;
        private AsyncRelayCommand _applyPreOrderChangesCommand;
        private DelegateCommand _changeEditModeCommand;
        private AsyncRelayCommand _reloadPreOrdersCommand;
        private AsyncRelayCommand _checkPreOrdersCommand;

        public PreOrdersTabViewModel(IPreOrdersService preOrdersService)
        {
            _preOrdersService = preOrdersService;
            PreOrders = new ObservableCollection<PreOrderEntityViewModel>();

            ReloadToysAsync()
                .Wait();
        }

        public DelegateCommand AddPreOrderCommand =>
            _addPreOrderCommand ??= new DelegateCommand(OnAddToyCommandExecuted);

        public DelegateCommand ChangeEditModeCommand =>
            _changeEditModeCommand ??=
                new DelegateCommand(OnChangeEditModeCommandExecuted, CanManipulateOnPreOrder)
                    .ObservesProperty(() => SelectedPreOrder);

        public AsyncRelayCommand RemovePreOrderCommand =>
            _removePreOrderCommand ??= new AsyncRelayCommand(OnRemoveToyCommandExecuted, CanManipulateOnPreOrder);

        public AsyncRelayCommand ApplyPreOrderChangesCommand =>
            _applyPreOrderChangesCommand ??=
                new AsyncRelayCommand(OnApplyToyChangesCommandExecuted);

        public AsyncRelayCommand ReloadPreOrdersCommand =>
            _reloadPreOrdersCommand ??= new AsyncRelayCommand(ReloadToysAsync);

        public AsyncRelayCommand CheckPreOrdersCommand =>
            _checkPreOrdersCommand ??= new AsyncRelayCommand(OnCheckPreOrdersExecuted);

        public ObservableCollection<PreOrderEntityViewModel> PreOrders
        {
            get => _preOrders;
            set => SetProperty(ref _preOrders, value);
        }

        public PreOrderEntityViewModel SelectedPreOrder
        {
            get => _selectedPreOrder;
            set
            {
                SetProperty(ref _selectedPreOrder, value);
                RemovePreOrderCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetProperty(ref _isEditMode, value);
        }

        private bool CanManipulateOnPreOrder() =>
            SelectedPreOrder is not null;

        private void OnChangeEditModeCommandExecuted() =>
            IsEditMode = !IsEditMode;

        private void OnAddToyCommandExecuted()
        {
            PreOrders.Insert(0,
                             new PreOrderEntityViewModel(new PreOrderEntity
                                                         {
                                                             PreOrderDate = DateTime.Now
                                                         }));

            SelectedPreOrder = PreOrders.First();
        }

        private async Task OnRemoveToyCommandExecuted()
        {
            if (SelectedPreOrder.Entity.Id == 0)
                PreOrders.Remove(SelectedPreOrder);

            await _preOrdersService.RemovePreOrderAsync(SelectedPreOrder.Entity);
            PreOrders.Remove(SelectedPreOrder);
            SelectedPreOrder = null;
        }

        private async Task OnApplyToyChangesCommandExecuted()
        {
            if (SelectedPreOrder.Entity.Id == 0)
                await _preOrdersService.AddPreOrderAsync(SelectedPreOrder.Entity);
            else
                await _preOrdersService.UpdatePreOrderAsync(SelectedPreOrder.Entity);

            await ReloadToysAsync();
        }

        private async Task ReloadToysAsync()
        {
            var preOrders = await _preOrdersService.GetAllPreOrdersAsync();
            PreOrders.Clear();

            foreach (var preOrder in preOrders)
                PreOrders.Add(new PreOrderEntityViewModel(preOrder));
        }

        private async Task OnCheckPreOrdersExecuted()
        {
            var toysForPreOrder = await _preOrdersService.GetAllPreOrdersAsync();
            var notClosedPreOrders = toysForPreOrder.Where(x => !x.IsDone);

            foreach (var order in notClosedPreOrders)
            {
                if (order.Toy.WarehouseCount > 0)
                    MessageBox.Show($"Found toy for PreOrder Id: {order.Id}{Environment.NewLine}Customer: Name: {order.Customer.FullName}, Phone: {order.Customer.PhoneNumber}.",
                                    "Found toy for PreOrder",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information,
                                    MessageBoxResult.OK);
            }
        }
    }
}