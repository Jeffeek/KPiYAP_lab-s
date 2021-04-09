#region Using namespaces

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Lab_no25.Model.Entities;
using Lab_no25.Services.Interfaces.EntityServices;
using Lab_no26plus27.Model.AsyncCommand;
using Lab_no26plus27.Model.SalesStatisticsPrinter;
using Lab_no26plus27.ViewModels.EntitiesViewModels;
using Prism.Commands;
using Prism.Mvvm;

#endregion

namespace Lab_no26plus27.ViewModels.TabsViewModels
{
    public class SalesTabViewModel : BindableBase
    {
        private readonly ISalesService _salesService;
        private readonly ISalesStatisticsPrinter _salesStatisticsPrinter;
        private bool _isEditMode;
        private ObservableCollection<SaleEntityViewModel> _sales;
        private SaleEntityViewModel _selectedSale;
        private DelegateCommand _addSaleCommand;
        private AsyncRelayCommand _removeSaleCommand;
        private AsyncRelayCommand _applySaleChangesCommand;
        private DelegateCommand _changeEditModeCommand;
        private AsyncRelayCommand _reloadSalesCommand;
        private AsyncRelayCommand _writeSalesStatisticsCommand;

        public SalesTabViewModel(ISalesService salesService,
                                 ISalesStatisticsPrinter salesStatisticsPrinter
            )
        {
            _salesService = salesService;
            _salesStatisticsPrinter = salesStatisticsPrinter;
            Sales = new ObservableCollection<SaleEntityViewModel>();

            ReloadToysCategoriesAsync()
                .Wait();
        }

        public DelegateCommand AddSaleCommand =>
            _addSaleCommand ??= new DelegateCommand(OnAddSaleCommandExecuted);

        public AsyncRelayCommand WriteSalesStatisticsCommand =>
            _writeSalesStatisticsCommand ??= new AsyncRelayCommand(() => _salesStatisticsPrinter.WriteAsync(_salesService.GetSalesByAsync(x => x.SaleDate.Day == DateTime.Now.Day)
                                                                                                                         .GetAwaiter()
                                                                                                                         .GetResult()));

        public AsyncRelayCommand RemoveSaleCommand =>
            _removeSaleCommand ??= new AsyncRelayCommand(OnRemoveToyCategoryCommandExecuted,
                                                         CanManipulateOnSale);

        public AsyncRelayCommand ApplySaleChangesCommand =>
            _applySaleChangesCommand ??= new AsyncRelayCommand(OnApplyToyCategoryChangesCommandExecuted);

        public DelegateCommand ChangeEditModeCommand =>
            _changeEditModeCommand ??= new DelegateCommand(OnChangeEditModeCommandExecuted,
                                                           CanManipulateOnSale)
                .ObservesProperty(() => SelectedSale);

        public AsyncRelayCommand ReloadSalesCommand =>
            _reloadSalesCommand ??= new AsyncRelayCommand(ReloadToysCategoriesAsync);

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
            }
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetProperty(ref _isEditMode, value);
        }

        private bool CanManipulateOnSale() =>
            SelectedSale is not null;

        private void OnChangeEditModeCommandExecuted() =>
            IsEditMode = !IsEditMode;

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
            if (SelectedSale.Entity.Id == 0)
                Sales.Remove(SelectedSale);

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

            foreach (var sale in dbSales)
                Sales.Add(new SaleEntityViewModel(sale));
        }
    }
}