#region Using namespaces

using System.Collections.Generic;
using System.Threading.Tasks;
using Lab_no25.Model;
using Lab_no25.Model.Entities;
using Lab_no25.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

#endregion

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
            var toy = await _context.Toys.FindAsync(sale.ToyId);

            if (toy is null) return false;

            var priceWithoutDiscount = sale.SaleCount * toy.Price;
            if (sale.Discount == 0)
            {
                sale.SaleSum = priceWithoutDiscount;
            }
            else
            {
                var discount = sale.Discount / 100m;
                sale.SaleSum = priceWithoutDiscount - priceWithoutDiscount * discount;
            }

            _context.Sales.Attach(sale);
            _context.Entry(sale).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<SaleEntity> GetByIdAsync(int id) => await _context.Sales.FindAsync(id);

        public async Task<IEnumerable<SaleEntity>> GetAllSalesAsync() =>
            await _context.Sales.Include(x => x.Toy).ThenInclude(x => x.Category).ToListAsync();
    }
}