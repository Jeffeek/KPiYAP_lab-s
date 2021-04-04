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
    public class SalesTabViewModel : BindableBase
    {
        private readonly ISalesService _salesService;
        private bool _isEditMode;
        private ObservableCollection<SaleEntityViewModel> _sales;
        private SaleEntityViewModel _selectedSale;

        public SalesTabViewModel(ISalesService salesService)
        {
            _salesService = salesService;
            Sales = new ObservableCollection<SaleEntityViewModel>();
            ChangeEditModeCommand = new DelegateCommand(OnChangeEditModeCommandExecuted, CanManipulateOnSale).ObservesProperty(() => SelectedSale);
            ApplySaleChangesCommand = new AsyncRelayCommand(OnApplyToyCategoryChangesCommandExecuted, CanManipulateOnSale);
            RemoveSaleCommand = new AsyncRelayCommand(OnRemoveToyCategoryCommandExecuted, CanManipulateOnSale);
            AddSaleCommand = new DelegateCommand(OnAddSaleCommandExecuted);
            ReloadSalesCommand = new AsyncRelayCommand(ReloadToysCategoriesAsync);
            ReloadToysCategoriesAsync().Wait();
        }

        public DelegateCommand AddSaleCommand { get; }

        public AsyncRelayCommand RemoveSaleCommand { get; }

        public AsyncRelayCommand ApplySaleChangesCommand { get; }

        public DelegateCommand ChangeEditModeCommand { get; }

        public AsyncRelayCommand ReloadSalesCommand { get; }

        public ObservableCollection<SaleEntityViewModel> Sales
        {
            get => _sales;
            set => SetProperty(ref _sales, value);
        }

        public SaleEntityViewModel SelectedSale
        {
            get => _selectedSale;
            set
            {
                SetProperty(ref _selectedSale, value);
                RemoveSaleCommand.RaiseCanExecuteChanged();
                ApplySaleChangesCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetProperty(ref _isEditMode, value);
        }

        private bool CanManipulateOnSale() => SelectedSale is not null;

        private void OnChangeEditModeCommandExecuted() => IsEditMode = !IsEditMode;

        private void OnAddSaleCommandExecuted()
        {
            Sales.Insert(0,
                         new SaleEntityViewModel(new SaleEntity
                                                 {
                                                     Discount = 0,
                                                     SaleCount = 0,
                                                     SaleDate = DateTime.Now,
                                                     ToyId = 1
                                                 }));
            SelectedSale = Sales.First();
        }

        private async Task OnRemoveToyCategoryCommandExecuted()
        {
            await _salesService.RemoveSaleAsync(SelectedSale.Entity);
            Sales.Remove(SelectedSale);
            SelectedSale = null;
        }

        private async Task OnApplyToyCategoryChangesCommandExecuted()
        {
            if (SelectedSale.Entity.Id == 0)
                await _salesService.AddSaleAsync(SelectedSale.Entity);
            else
                await _salesService.UpdateSaleAsync(SelectedSale.Entity);
            await ReloadToysCategoriesAsync();
        }

        private async Task ReloadToysCategoriesAsync()
        {
            var dbSales = await _salesService.GetAllSalesAsync();
            Sales.Clear();
            foreach (var sale in dbSales) Sales.Add(new SaleEntityViewModel(sale));
        }
    }
}