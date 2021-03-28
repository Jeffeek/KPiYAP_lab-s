using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab_no25.Model.Entities;
using Lab_no25.Services.Interfaces;
using Lab_no26.Model;
using Lab_no26.Model.Editors;

namespace Lab_no26.ViewModel
{
    public class MainWindowViewModel
    {
        private readonly ISalesService _salesService;
        private readonly IToysCategoriesService _toysCategoriesService;
        private readonly IToysService _toysService;

        public ICommand AddToyCommand { get; }
        public ICommand AddToyCategoryCommand { get; }
        public ICommand AddSaleCommand { get; }

        public ObservableCollection<ToyEntityViewModel> Toys { get; private set; }

        public ObservableCollection<ToyCategoryEntityViewModel> ToysCategories { get; private set;  }

        public ObservableCollection<SaleEntityViewModel> Sales { get; private set;  }

        public ToyEntityEditorViewModel ToyEditor { get; private set; }

        public MainWindowViewModel(ISalesService salesService,
                                   IToysCategoriesService toysCategoriesService,
                                   IToysService toysService)
        {
            _salesService = salesService;
            _toysCategoriesService = toysCategoriesService;
            _toysService = toysService;
            InitializeCollections();
        }

        private async Task InitializeCollections()
        {
            var dbToys = await _toysService.GetAllToysAsync();
            var dbToysCategories = await _toysCategoriesService.GetAllToysCategoriesAsync();
            var dbSales = await _salesService.GetAllSalesAsync();
            Toys = new ObservableCollection<ToyEntityViewModel>();
            foreach (var toy in dbToys)
                Toys.Add(new ToyEntityViewModel(Toys, toy, _toysService));
            ToysCategories = new ObservableCollection<ToyCategoryEntityViewModel>();
            foreach (var toyCategory in dbToysCategories)
                ToysCategories.Add(new ToyCategoryEntityViewModel(ToysCategories, toyCategory, _toysCategoriesService));
            Sales = new ObservableCollection<SaleEntityViewModel>();
            foreach (var sale in dbSales)
                Sales.Add(new SaleEntityViewModel(Sales, sale, _salesService));
        }
    }
}
