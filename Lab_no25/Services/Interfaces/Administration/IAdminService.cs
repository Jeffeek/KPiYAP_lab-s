using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_no25.Services.Interfaces.EntityServices;

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