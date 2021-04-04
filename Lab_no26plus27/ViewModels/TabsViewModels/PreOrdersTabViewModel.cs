#region Using namespaces

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
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
        private readonly IPreOrdersService _preOrdersService;
        private bool _isEditMode;
        private ObservableCollection<PreOrderEntityViewModel> _preOrders;
        private PreOrderEntityViewModel _selectedPreOrder;

        public PreOrdersTabViewModel(IPreOrdersService preOrdersService)
        {
            _preOrdersService = preOrdersService;
            PreOrders = new ObservableCollection<PreOrderEntityViewModel>();
            ChangeEditModeCommand =
                new DelegateCommand(OnChangeEditModeCommandExecuted, CanManipulateOnPreOrder).ObservesProperty(() => SelectedPreOrder);
            ApplyPreOrderChangesCommand = new AsyncRelayCommand(OnApplyToyChangesCommandExecuted, CanManipulateOnPreOrder);
            RemovePreOrderCommand = new AsyncRelayCommand(OnRemoveToyCommandExecuted, CanManipulateOnPreOrder);
            AddPreOrderCommand = new DelegateCommand(OnAddToyCommandExecuted);
            ReloadPreOrdersCommand = new AsyncRelayCommand(ReloadToysAsync);
            ReloadToysAsync().Wait();
        }

        public DelegateCommand AddPreOrderCommand { get; }

        public AsyncRelayCommand RemovePreOrderCommand { get; }

        public AsyncRelayCommand ApplyPreOrderChangesCommand { get; }

        public DelegateCommand ChangeEditModeCommand { get; }

        public AsyncRelayCommand ReloadPreOrdersCommand { get; }

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
                ApplyPreOrderChangesCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetProperty(ref _isEditMode, value);
        }

        private bool CanManipulateOnPreOrder() => SelectedPreOrder is not null;

        private void OnChangeEditModeCommandExecuted() => IsEditMode = !IsEditMode;

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
            foreach (var preOrder in preOrders) PreOrders.Add(new PreOrderEntityViewModel(preOrder));
        }
    }
}