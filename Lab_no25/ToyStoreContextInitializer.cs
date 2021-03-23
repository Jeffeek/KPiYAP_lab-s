using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_no25.Model;
using Lab_no25.Model.Entities;

namespace Lab_no25
{
    public class ToyStoreContextInitializer
    {
        public async Task Initialize(ToyStoreDbContext context)
        {
            var random = new Random();
            var categories = new List<ToyCategoryEntity>();
            var toys = new List<ToyEntity>();
            var sales = new List<SaleEntity>();

            for (var i = 0; i < 20; i++)
            {
                var toyCategory = new ToyCategoryEntity
                                  {
                                      Age = random.Next(1, 20),
                                      CareRules = Guid.NewGuid().ToString().Replace("-", "").ToUpper(),
                                      WarrantyPeriod = random.Next(1, 128)
                                  };
                categories.Add(toyCategory);
            }

            for (var i = 0; i < 100; i++)
            {
                var toy = new ToyEntity
                          {
                              Category = categories[random.Next(0, categories.Count)],
                              Photo = $"photo{i + random.Next(0, 20000)}{Guid.NewGuid()}",
                              Price = (decimal)(random.NextDouble() * random.Next(1, 5000)),
                              Producer = Guid.NewGuid().ToString().Substring(0, 7).Replace("-", ""),
                              WarehouseCount = random.Next(0, 10000)
                          };
                toys.Add(toy);
            }

            for (var i = 0; i < 1000; i++)
            {
                var selectedToy = toys[random.Next(0, toys.Count)];
                var discount = random.Next(0, 80);
                var count = random.Next(1, 100);
                var price = selectedToy.Price * count * 100 / (discount == 0 ? 1 : discount);
                var sale = new SaleEntity
                           {
                               Discount = discount,
                               SaleDate = DateTime.Now,
                               SaleSum = price,
                               Toy = selectedToy,
                               SaleCount = count
                           };
                sales.Add(sale);
            }

            await context.ToyCategories.AddRangeAsync(categories);
            await context.Toys.AddRangeAsync(toys);
            await context.Sales.AddRangeAsync(sales);
            await context.SaveChangesAsync();
        }
    }
}
