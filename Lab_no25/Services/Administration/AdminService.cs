#region Using namespaces

using Lab_no25.Services.Interfaces.Administration;
using Lab_no25.Services.Interfaces.EntityServices;

#endregion

namespace Lab_no25.Services.Administration
{
    public class AdminService : IAdminService
    {
        public AdminService(IToysCategoriesService toysCategoriesService,
                            IToysService toysService,
                            IPreOrdersService preOrdersService,
                            ICustomersService customersService,
                            ISalesService salesService
            )
        {
            ToysCategoriesService = toysCategoriesService;
            ToysService = toysService;
            PreOrdersService = preOrdersService;
            CustomersService = customersService;
            SalesService = salesService;
        }

        public IToysCategoriesService ToysCategoriesService { get; }

        public IToysService ToysService { get; }

        public IPreOrdersService PreOrdersService { get; }

        public ICustomersService CustomersService { get; }

        public ISalesService SalesService { get; }
    }
}