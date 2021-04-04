using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_no25.Model;
using Lab_no25.Model.Entities;
using Lab_no25.Services.Interfaces.EntityServices;
using Microsoft.EntityFrameworkCore;

namespace Lab_no25.Services.Implementations
{
    public class CustomersService : ICustomersService
    {
        private readonly ToyStoreDbContext _context;

        public CustomersService(ToyStoreDbContext context) => _context = context;

        public async Task<bool> AddCustomerAsync(CustomerEntity customer)
        {
            await _context.Customers.AddAsync(customer);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveCustomerAsync(CustomerEntity customer)
        {
            _context.Customers.Attach(customer);
            _context.Customers.Remove(customer);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCustomerAsync(CustomerEntity customer)
        {
            _context.Attach(customer);
            _context.Entry(customer).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<CustomerEntity> GetByIdAsync(int id) => await _context.Customers.FindAsync(id);

        public async Task<IEnumerable<CustomerEntity>> GetAllCustomersAsync() =>
            await _context.Customers
                          .Include(x => x.PreOrders)
                          .ToListAsync();
    }
}
