#region Using namespaces

using System.Collections.Generic;
using System.Threading.Tasks;
using Lab_no25.Model.Entities;

#endregion

namespace Lab_no25.Services.Interfaces
{
    public interface IToysService
    {
        Task<bool> AddToyAsync(ToyEntity toy);

        Task<bool> RemoveToyAsync(ToyEntity toy);

        Task<bool> UpdateToyAsync(ToyEntity toy);

        Task<ToyEntity> GetByIdAsync(int id);

        Task<IEnumerable<ToyEntity>> GetAllToysAsync();
    }
}