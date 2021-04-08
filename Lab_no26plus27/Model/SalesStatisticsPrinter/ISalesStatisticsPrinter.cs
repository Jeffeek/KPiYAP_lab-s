#region Using namespaces

using System.Collections.Generic;
using System.Threading.Tasks;
using Lab_no25.Model.Entities;

#endregion

namespace Lab_no26plus27.Model.SalesStatisticsPrinter
{
    public interface ISalesStatisticsPrinter
    {
        void Write(IEnumerable<SaleEntity> sales);

        Task WriteAsync(IEnumerable<SaleEntity> sales);
    }
}