#region Using namespaces

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab_no25.Model.Entities;
using Lab_no25.Services.Interfaces.Administration;
using Lab_no25.Services.Interfaces.EntityServices;

#endregion

namespace Lab_no25.Services.Administration
{
    public class ManagerService : IManagerService
    {
        public ManagerService(IPreOrdersService preOrdersService,
                              ISalesService salesService,
                              ICustomersService customersService
            )
        {
            PreOrdersService = preOrdersService;
            SalesService = salesService;
            CustomersService = customersService;
        }

        public IPreOrdersService PreOrdersService { get; }

        public ISalesService SalesService { get; }

        public ICustomersService CustomersService { get; }

        public async Task PlacePreOrderAsync(int toyId, int customerId) =>
            await PreOrdersService.AddPreOrderAsync(new PreOrderEntity
                                                    {
                                                        CustomerId = (uint)customerId,
                                                        PreOrderDate = DateTime.Now,
                                                        ToyId = (uint)toyId
                                                    });

        public async Task<IEnumerable<SaleEntity>> UnloadTodaySalesAsync() =>
            await SalesService.GetSalesByAsync(x => x.SaleDate.Day == DateTime.Now.Day);
    }
}