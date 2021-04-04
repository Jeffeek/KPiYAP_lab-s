#region Using namespaces

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lab_no25.Model.Entities;

#endregion

namespace Lab_no25.Services.Interfaces.EntityServices
{
    public interface ISalesService
    {
        Task<bool> AddSaleAsync(SaleEntity sale);

        Task<bool> RemoveSaleAsync(SaleEntity sale);

        Task<bool> UpdateSaleAsync(SaleEntity sale);

        Task<IEnumerable<SaleEntity>> GetSalesByAsync(Expression<Func<SaleEntity, bool>> predicate);

        Task<SaleEntity> GetByIdAsync(int id);

        Task<IEnumerable<SaleEntity>> GetAllSalesAsync();
    }
}