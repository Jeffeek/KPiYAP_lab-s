using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using Lab_no25;
using Lab_no25.Model;
using Lab_no25.Services;
using Lab_no25.Services.Interfaces;
using Lab_no26.View;
using Lab_no26.ViewModel;
using Ninject;
using Ninject.Activation;

namespace Lab_no26
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() { }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IKernel kernel = new StandardKernel();
            kernel.Load(typeof(NinjectRegistration).Assembly);

            var context = kernel.Get<ToyStoreDbContext>();
            //var toysService = kernel.Get<IToysService>();
            //var toysCategoriesService = kernel.Get<IToysCategoriesService>();
            //var salesService = kernel.Get<ISalesService>();

            var initializer = new ToyStoreContextInitializer();
            _ = initializer.Initialize(context);

            kernel.Bind<MainWindowViewModel>().ToSelf().InSingletonScope();
            var viewModel = kernel.GetService(typeof(MainWindowViewModel));

            var mainWindow = new MainWindow
                             {
                                 DataContext = viewModel
                             };
            mainWindow.Show();
        }
    }
}
