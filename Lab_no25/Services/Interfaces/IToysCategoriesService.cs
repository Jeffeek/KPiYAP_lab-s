using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_no25.Model.Entities;

namespace Lab_no25.Services.Interfaces
{
    public interface IToysCategoriesService
    {
        Task<bool> AddToyCategoryAsync(ToyCategoryEntity toyCategory);

        Task<bool> RemoveToyCategoryAsync(ToyCategoryEntity toyCategory);

        Task<bool> UpdateToyCategoryAsync(ToyCategoryEntity toyCategory);

        Task<ToyCategoryEntity> GetByIdAsync(int id);
    }
}
