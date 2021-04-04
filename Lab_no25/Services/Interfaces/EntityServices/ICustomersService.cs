using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_no25.Model.Entities;

namespace Lab_no25.Services.Interfaces.EntityServices
{
    public interface ICustomersService
    {
        Task<bool> AddCustomerAsync(CustomerEntity customer);

        Task<bool> RemoveCustomerAsync(CustomerEntity customer);

        Task<bool> UpdateCustomerAsync(CustomerEntity customer);

        Task<CustomerEntity> GetByIdAsync(int id);

        Task<IEnumerable<CustomerEntity>> GetAllCustomersAsync();
    }
}
