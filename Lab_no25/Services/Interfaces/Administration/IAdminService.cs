#region Using namespaces

using Lab_no25.Services.Interfaces.EntityServices;

#endregion

namespace Lab_no25.Services.Interfaces.Administration
{
    public interface IAdminService
    {
        IToysCategoriesService ToysCategoriesService { get; }

        IToysService ToysService { get; }

        IPreOrdersService PreOrdersService { get; }

        ICustomersService CustomersService { get; }

        ISalesService SalesService { get; }
    }
}