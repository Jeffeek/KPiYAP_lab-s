#region Using namespaces

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Lab_no25.Model.Entities;
using Lab_no25.Services.Interfaces;
using Lab_no26plus27.Model.AsyncCommand;
using Lab_no26plus27.ViewModel.EntitiesViewModels;

#endregion

namespace Lab_no26plus27.ViewModel.TabsViewModels
{
    public class SalesTabViewModel : ViewModelBase
    {
        private readonly ISalesService _salesService;
        private bool _isEditMode;
        private ObservableCollection<SaleEntityViewModel> _sales;
        private SaleEntityViewModel _selectedSale;

        public SalesTabViewModel(ISalesService salesService)
        {
            _salesService = salesService;
            Sales = new ObservableCollection<SaleEntityViewModel>();
            ChangeEditModeCommand = new RelayCommand(OnChangeEditModeCommandExecuted);
            ApplySaleChangesCommand = new AsyncRelayCommand(OnApplyToyCategoryChangesCommandExecuted);
            RemoveSaleCommand = new AsyncRelayCommand(OnRemoveToyCategoryCommandExecuted);
            AddSaleCommand = new RelayCommand(OnAddSaleCommandExecuted);
            ReloadSalesCommand = new AsyncRelayCommand(ReloadToysCategoriesAsync);
            ReloadToysCategoriesAsync();
        }

        public ICommand AddSaleCommand { get; }

        public ICommand RemoveSaleCommand { get; }

        public ICommand ApplySaleChangesCommand { get; }

        public ICommand ChangeEditModeCommand { get; }

        public ICommand ReloadSalesCommand { get; }

        public ObservableCollection<SaleEntityViewModel> Sales
        {
            get => _sales;
            set => Set(ref _sales, value);
        }

        public SaleEntityViewModel SelectedSale
        {
            get => _selectedSale;
            set => Set(ref _selectedSale, value);
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set => Set(ref _isEditMode, value);
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
            if (!CanManipulateOnSale()) return;

            await _salesService.RemoveSaleAsync(SelectedSale.Entity);
            Sales.Remove(SelectedSale);
            SelectedSale = null;
        }

        private async Task OnApplyToyCategoryChangesCommandExecuted()
        {
            if (!CanManipulateOnSale()) return;

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