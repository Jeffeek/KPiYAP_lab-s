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
    public class ToysService : IToysService
    {
        private readonly ToyStoreDbContext _context;

        public ToysService(ToyStoreDbContext context) => _context = context;

        public async Task<bool> AddToyAsync(ToyEntity toy)
        {
            await _context.Toys.AddAsync(toy);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveToyAsync(ToyEntity toy)
        {
            _context.Toys.Attach(toy);
            _context.Toys.Remove(toy);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateToyAsync(ToyEntity toy)
        {
            _context.Entry(toy).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ToyEntity> GetByIdAsync(int id) => await _context.Toys.FindAsync(id);
    }
}
