using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_no25.Model.Entities;

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
