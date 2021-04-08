#region Using namespaces

using System.Collections.Generic;
using System.Threading.Tasks;
using Lab_no25.Model.Entities;

#endregion

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