#region Using namespaces

using System.Windows.Controls;
using Lab_no26plus27.Model;
using Lab_no26plus27.Views;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

#endregion

namespace Lab_no26plus27.ViewModels.WindowsViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;

        public MainWindowViewModel(IRegionManager regionManager,
                                   IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

            _regionManager.RegisterViewWithRegion("CurrentPage", () => ContainerLocator.Container.Resolve<SignInPage>());
            _regionManager.RegisterViewWithRegion("CurrentPage", () => ContainerLocator.Container.Resolve<AdminPage>());
            _regionManager.RegisterViewWithRegion("CurrentPage", () => ContainerLocator.Container.Resolve<ManagerPage>());

            _eventAggregator.GetEvent<PubSubEvent<string>>()
                            .Subscribe(x =>
                                           _regionManager.RequestNavigate("CurrentPage",
                                                                          x == ApplicationRoles.Administrator ? "AdministratorPage" : "ManagerPage"));
            regionManager.RequestNavigate("CurrentPage", "SignInPage");
        }
    }
}