#region Using namespaces

using System.Collections.Generic;
using System.Threading.Tasks;
using Lab_no25.Model.Entities;

#endregion

namespace Lab_no25.Services.Interfaces.EntityServices
{
    public interface IPreOrdersService
    {
        Task<bool> AddPreOrderAsync(PreOrderEntity preOrder);

        Task<bool> RemovePreOrderAsync(PreOrderEntity preOrder);

        Task<bool> UpdatePreOrderAsync(PreOrderEntity preOrder);

        Task<PreOrderEntity> GetByIdAsync(int id);

        Task<IEnumerable<PreOrderEntity>> GetAllPreOrdersAsync();
    }
}