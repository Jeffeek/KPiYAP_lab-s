#region Using namespaces

using System.Windows;
using System.Windows.Navigation;
using Lab_no25;
using Lab_no25.Model;
using Lab_no25.Services.Implementations;
using Lab_no25.Services.Interfaces.EntityServices;
using Lab_no26plus27.ViewModels;
using Lab_no26plus27.ViewModels.PagesViewModels;
using Lab_no26plus27.ViewModels.WindowsViewModels;
using Lab_no26plus27.Views;
using Microsoft.EntityFrameworkCore;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;

#endregion

namespace Lab_no26plus27
{
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var options = new DbContextOptionsBuilder<ToyStoreDbContext>().UseInMemoryDatabase("Customers").Options;
            containerRegistry.RegisterSingleton<ToyStoreDbContext>(() =>
                                                                   {
                                                                       var initializer = new ToyStoreContextInitializer();
                                                                       var context = new ToyStoreDbContext(options);
                                                                       initializer.Initialize(context).Wait();

                                                                       return context;
                                                                   });

            containerRegistry.RegisterScoped<IToysCategoriesService, ToysCategoriesService>();
            containerRegistry.RegisterScoped<IToysService, ToysService>();
            containerRegistry.RegisterScoped<ISalesService, SalesService>();
            containerRegistry.RegisterScoped<ICustomersService, CustomersService>();
            containerRegistry.RegisterScoped<IPreOrdersService, PreOrdersService>();

            containerRegistry.RegisterForNavigation<SignInPage, SignInPageViewModel>("SignInPage");
            containerRegistry.RegisterForNavigation<AdminPage, AdminPageViewModel>("AdministratorPage");
            containerRegistry.RegisterForNavigation<ManagerPage, ManagerPageViewModel>("ManagerPage");

            containerRegistry.Register<MainWindow>(() => new MainWindow()
                                                         {
                                                             DataContext = new MainWindowViewModel(Container.Resolve<IRegionManager>(),
                                                                 Container.Resolve<IEventAggregator>())
                                                         });
        }

        protected override Window CreateShell() => Container.Resolve<MainWindow>();
    }
}