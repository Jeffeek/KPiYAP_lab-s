#region Using namespaces

using System.Collections.Generic;
using System.Threading.Tasks;
using Lab_no25.Model;
using Lab_no25.Model.Entities;
using Lab_no25.Services.Interfaces.EntityServices;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Lab_no25.Services.Implementations
{
    public class PreOrdersService : IPreOrdersService
    {
        private readonly ToyStoreDbContext _context;

        public PreOrdersService(ToyStoreDbContext context) =>
            _context = context;

        public async Task<bool> AddPreOrderAsync(PreOrderEntity preOrder)
        {
            await _context.PreOrders.AddAsync(preOrder);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemovePreOrderAsync(PreOrderEntity preOrder)
        {
            _context.PreOrders.Attach(preOrder);
            _context.PreOrders.Remove(preOrder);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePreOrderAsync(PreOrderEntity preOrder)
        {
            _context.Attach(preOrder);

            _context.Entry(preOrder)
                    .State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<PreOrderEntity> GetByIdAsync(int id) =>
            await _context.PreOrders.FindAsync(id);

        public async Task<IEnumerable<PreOrderEntity>> GetAllPreOrdersAsync() =>
            await _context.PreOrders
                          .Include(x => x.Toy)
                          .ThenInclude(x => x.Category)
                          .Include(x => x.Customer)
                          .ToListAsync();
    }
}