using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab_no25.Model.Entities;
using Lab_no25.Services.Interfaces.EntityServices;
using Lab_no26plus27.Model.AsyncCommand;
using Lab_no26plus27.ViewModels.EntitiesViewModels;
using Prism.Commands;
using Prism.Mvvm;

namespace Lab_no26plus27.ViewModels.TabsViewModels
{
    public class PreOrdersTabViewModel : BindableBase
    {
        private readonly IPreOrdersService _preOrdersService;
        private bool _isEditMode;
        private PreOrderEntityViewModel _selectedPreOrder;
        private ObservableCollection<PreOrderEntityViewModel> _preOrders;

        public PreOrdersTabViewModel(IPreOrdersService preOrdersService)
        {
            _preOrdersService = preOrdersService;
            PreOrders = new ObservableCollection<PreOrderEntityViewModel>();
            ChangeEditModeCommand = new DelegateCommand(OnChangeEditModeCommandExecuted);
            ApplyPreOrderChangesCommand = new AsyncRelayCommand(OnApplyToyChangesCommandExecuted);
            RemovePreOrderCommand = new AsyncRelayCommand(OnRemoveToyCommandExecuted);
            AddPreOrderCommand = new DelegateCommand(OnAddToyCommandExecuted);
            ReloadPreOrdersCommand = new AsyncRelayCommand(ReloadToysAsync);
            ReloadToysAsync().Wait();
        }

        public ICommand AddPreOrderCommand { get; }

        public ICommand RemovePreOrderCommand { get; }

        public ICommand ApplyPreOrderChangesCommand { get; }

        public ICommand ChangeEditModeCommand { get; }

        public ICommand ReloadPreOrdersCommand { get; }

        public ObservableCollection<PreOrderEntityViewModel> PreOrders
        {
            get => _preOrders;
            set => SetProperty(ref _preOrders, value);
        }

        public PreOrderEntityViewModel SelectedCustomer
        {
            get => _selectedPreOrder;
            set => SetProperty(ref _selectedPreOrder, value);
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetProperty(ref _isEditMode, value);
        }

        private bool CanManipulateOnPreOrder() => SelectedCustomer is not null;

        private void OnChangeEditModeCommandExecuted() => IsEditMode = !IsEditMode;

        private void OnAddToyCommandExecuted()
        {
            PreOrders.Insert(0,
                             new PreOrderEntityViewModel(new PreOrderEntity()
                                                         {
                                                             PreOrderDate = DateTime.Now
                                                         }));
            SelectedCustomer = PreOrders.First();
        }

        private async Task OnRemoveToyCommandExecuted()
        {
            if (!CanManipulateOnPreOrder()) return;

            await _preOrdersService.RemovePreOrderAsync(SelectedCustomer.Entity);
            PreOrders.Remove(SelectedCustomer);
            SelectedCustomer = null;
        }

        private async Task OnApplyToyChangesCommandExecuted()
        {
            if (!CanManipulateOnPreOrder()) return;

            if (SelectedCustomer.Entity.Id == 0)
                await _preOrdersService.AddPreOrderAsync(SelectedCustomer.Entity);
            else
                await _preOrdersService.UpdatePreOrderAsync(SelectedCustomer.Entity);
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
