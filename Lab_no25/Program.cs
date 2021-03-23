using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Lab_no25.Model;
using Lab_no25.Model.Entities;
using Lab_no25.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ninject;

namespace Lab_no25
{
    class Program
    {
        private static IKernel _kernel;

        static async Task Main(string[] args)
        {
            _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());

            var context = _kernel.Get<ToyStoreDbContext>();
            var toysService = _kernel.Get<IToysService>();
            var toysCategoriesService = _kernel.Get<IToysCategoriesService>();
            var salesService = _kernel.Get<ISalesService>();

            var initializer = new ToyStoreContextInitializer();
            await initializer.Initialize(context);
        }
    }
}
