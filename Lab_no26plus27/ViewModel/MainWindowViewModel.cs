#region Using namespaces

using GalaSoft.MvvmLight;
using Lab_no25.Services.Interfaces;
using Lab_no26plus27.ViewModel.TabsViewModels;

#endregion

namespace Lab_no26plus27.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private SalesTabViewModel _salesContext;
        private ToysCategoriesTabViewModel _toysCategoriesContext;
        private ToysTabViewModel _toysContext;

        public MainWindowViewModel(IToysService toysService,
                                   IToysCategoriesService categoriesService,
                                   ISalesService salesService)
        {
            ToysContext = new ToysTabViewModel(toysService);
            ToysCategoriesContext = new ToysCategoriesTabViewModel(categoriesService);
            SalesContext = new SalesTabViewModel(salesService);
        }

        public ToysTabViewModel ToysContext
        {
            get => _toysContext;
            set => Set(ref _toysContext, value);
        }

        public ToysCategoriesTabViewModel ToysCategoriesContext
        {
            get => _toysCategoriesContext;
            set => Set(ref _toysCategoriesContext, value);
        }

        public SalesTabViewModel SalesContext
        {
            get => _salesContext;
            set => Set(ref _salesContext, value);
        }
    }
}