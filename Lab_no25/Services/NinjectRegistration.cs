#region Using namespaces

using Lab_no25.Model;
using Lab_no25.Services.Implementations;
using Lab_no25.Services.Interfaces;
using Lab_no25.Services.Interfaces.EntityServices;
using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using Ninject.Parameters;

#endregion

namespace Lab_no25.Services
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            var options = new DbContextOptionsBuilder<ToyStoreDbContext>().UseInMemoryDatabase("Toys").Options;
            Bind<ToyStoreDbContext>()
                .ToSelf()
                .InThreadScope()
                .WithParameter(new ConstructorArgument("options", options));
            Bind<IToysCategoriesService>().To<ToysCategoriesService>();
            Bind<IToysService>().To<ToysService>();
            Bind<ISalesService>().To<SalesService>();
            Bind<ICustomersService>().To<CustomersService>();
            Bind<IPreOrdersService>().To<PreOrdersService>();
        }
    }
}