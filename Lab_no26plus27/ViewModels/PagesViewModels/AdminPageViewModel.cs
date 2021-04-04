using Lab_no25.Services.Interfaces.EntityServices;
using Lab_no26plus27.ViewModels.TabsViewModels;
using Prism.Mvvm;

namespace Lab_no26plus27.ViewModels.PagesViewModels
{
    public class AdminPageViewModel : BindableBase
    {
        private SalesTabViewModel _salesContext;
        private ToysCategoriesTabViewModel _toysCategoriesContext;
        private ToysTabViewModel _toysContext;
        private CustomersTabViewModel _customersContext;
        private PreOrdersTabViewModel _preOrdersContext;

        public AdminPageViewModel(IToysService toysService,
                                  IToysCategoriesService categoriesService,
                                  ISalesService salesService,
                                  ICustomersService customersService,
                                  IPreOrdersService preOrdersService)
        {
            ToysContext = new ToysTabViewModel(toysService);
            ToysCategoriesContext = new ToysCategoriesTabViewModel(categoriesService);
            SalesContext = new SalesTabViewModel(salesService);
            CustomersContext = new CustomersTabViewModel(customersService);
            PreOrdersContext = new PreOrdersTabViewModel(preOrdersService);
        }

        public PreOrdersTabViewModel PreOrdersContext
        {
            get => _preOrdersContext; 
            set => SetProperty(ref _preOrdersContext, value);
        }

        public CustomersTabViewModel CustomersContext
        {
            get => _customersContext;
            set => SetProperty(ref _customersContext, value);
        }

        public ToysTabViewModel ToysContext
        {
            get => _toysContext;
            set => SetProperty(ref _toysContext, value);
        }

        public ToysCategoriesTabViewModel ToysCategoriesContext
        {
            get => _toysCategoriesContext;
            set => SetProperty(ref _toysCategoriesContext, value);
        }

        public SalesTabViewModel SalesContext
        {
            get => _salesContext;
            set => SetProperty(ref _salesContext, value);
        }
    }
}
