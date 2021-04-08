#region Using namespaces

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Lab_no25.Model.Entities;

#endregion

namespace Lab_no26plus27.Model.SalesStatisticsPrinter
{
    public class FileSalesStatisticsPrinter : ISalesStatisticsPrinter
    {
        private readonly string _path = $"{Directory.GetCurrentDirectory()}\\SalesStatistics";

        public FileSalesStatisticsPrinter()
        {
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
        }

        private string GetContent(IEnumerable<SaleEntity> sales)
        {
            if (sales is null)
                throw new ArgumentNullException(nameof(sales));

            var content = String.Join(Environment.NewLine, sales);

            return content;
        }

        #region Implementation of ISalesStatisticsPrinter

        /// <inheritdoc/>
        public void Write(IEnumerable<SaleEntity> sales) =>
            File.WriteAllText(Path.Combine(_path, $"sales_{DateTime.Now:ddyyyy}.txt"),
                              GetContent(sales));

        /// <inheritdoc/>
        public async Task WriteAsync(IEnumerable<SaleEntity> sales) =>
            await File.WriteAllTextAsync(Path.Combine(_path, $"sales_{DateTime.Now:ddyyyy}.txt"),
                                         GetContent(sales));

        #endregion
    }
}