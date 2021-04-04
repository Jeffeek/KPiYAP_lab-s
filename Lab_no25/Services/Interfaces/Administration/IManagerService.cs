using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_no25.Model.Entities;
using Lab_no25.Services.Interfaces.EntityServices;

namespace Lab_no25.Services.Interfaces.Administration
{
    public interface IManagerService
    {
        IPreOrdersService PreOrdersService { get; }

        ISalesService SalesService { get; }

        ICustomersService CustomersService { get; }

        Task PlacePreOrderAsync(int toyId, int customerId);

        Task<IEnumerable<SaleEntity>> UnloadTodaySalesAsync();
    }
}