#region Using namespaces

using System.Collections.Generic;
using System.Threading.Tasks;
using Lab_no25.Model.Entities;

#endregion

namespace Lab_no25.Services.Interfaces.EntityServices
{
    public interface IToysCategoriesService
    {
        Task<bool> AddToyCategoryAsync(ToyCategoryEntity toyCategory);

        Task<bool> RemoveToyCategoryAsync(ToyCategoryEntity toyCategory);

        Task<bool> UpdateToyCategoryAsync(ToyCategoryEntity toyCategory);

        Task<ToyCategoryEntity> GetByIdAsync(int id);

        Task<IEnumerable<ToyCategoryEntity>> GetAllToysCategoriesAsync();
    }
}