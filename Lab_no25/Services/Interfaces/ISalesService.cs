using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_no25.Model.Entities;

namespace Lab_no25.Services.Interfaces
{
    public interface ISalesService
    {
        Task<bool> AddSaleAsync(SaleEntity sale);

        Task<bool> RemoveSaleAsync(SaleEntity sale);

        Task<bool> UpdateSaleAsync(SaleEntity sale);

        Task<SaleEntity> GetByIdAsync(int id);
    }
}
