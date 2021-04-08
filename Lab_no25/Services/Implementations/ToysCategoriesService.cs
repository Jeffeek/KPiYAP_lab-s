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
    public class ToysCategoriesService : IToysCategoriesService
    {
        private readonly ToyStoreDbContext _context;

        public ToysCategoriesService(ToyStoreDbContext context) =>
            _context = context;

        public async Task<bool> AddToyCategoryAsync(ToyCategoryEntity toyCategory)
        {
            await _context.ToyCategories.AddAsync(toyCategory);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveToyCategoryAsync(ToyCategoryEntity toyCategory)
        {
            _context.ToyCategories.Attach(toyCategory);
            _context.ToyCategories.Remove(toyCategory);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateToyCategoryAsync(ToyCategoryEntity toyCategory)
        {
            _context.Entry(toyCategory)
                    .State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ToyCategoryEntity> GetByIdAsync(int id) =>
            await _context.ToyCategories.FindAsync(id);

        public async Task<IEnumerable<ToyCategoryEntity>> GetAllToysCategoriesAsync() =>
            await _context.ToyCategories.ToListAsync();
    }
}