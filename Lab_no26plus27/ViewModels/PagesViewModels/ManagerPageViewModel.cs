using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_no25.Services.Interfaces.EntityServices;
using Lab_no26plus27.ViewModels.TabsViewModels;
using Prism.Mvvm;

namespace Lab_no26plus27.ViewModels.PagesViewModels
{
    public class ManagerPageViewModel : BindableBase
    {
        private SalesTabViewModel _salesContext;
        private ToysTabViewModel _toysContext;
        private CustomersTabViewModel _customersContext;
        private PreOrdersTabViewModel _preOrdersContext;

        public ManagerPageViewModel(IToysService toysService,
                                    ISalesService salesService,
                                    ICustomersService customersService,
                                    IPreOrdersService preOrdersService)
        {
            ToysContext = new ToysTabViewModel(toysService);
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

        public SalesTabViewModel SalesContext
        {
            get => _salesContext;
            set => SetProperty(ref _salesContext, value);
        }
    }
}
