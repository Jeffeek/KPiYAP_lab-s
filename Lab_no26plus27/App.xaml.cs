#region Using namespaces

using System.Windows;
using Lab_no25;
using Lab_no25.Model;
using Lab_no25.Services;
using Lab_no26plus27.View;
using Lab_no26plus27.ViewModel;
using Ninject;

#endregion

namespace Lab_no26plus27
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IKernel kernel = new StandardKernel();
            kernel.Load(typeof(NinjectRegistration).Assembly);

            var context = kernel.Get<ToyStoreDbContext>();

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