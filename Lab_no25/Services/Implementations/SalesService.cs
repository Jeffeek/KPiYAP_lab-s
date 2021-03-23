using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_no25.Model;
using Lab_no25.Model.Entities;
using Lab_no25.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab_no25.Services.Implementations
{
    public class SalesService : ISalesService
    {
        private readonly ToyStoreDbContext _context;

        public SalesService(ToyStoreDbContext context) => _context = context;

        public async Task<bool> AddSaleAsync(SaleEntity sale)
        {
            await _context.Sales.AddAsync(sale);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveSaleAsync(SaleEntity sale)
        {
            _context.Sales.Attach(sale);
            _context.Sales.Remove(sale);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateSaleAsync(SaleEntity sale)
        {
            _context.Entry(sale).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<SaleEntity> GetByIdAsync(int id) => await _context.Sales.FindAsync(id);
    }
}
