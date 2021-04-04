using System;
using System.Collections.Generic;
using System.Windows;
using Lab_no26plus27.Model;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace Lab_no26plus27.ViewModels.PagesViewModels
{
    public class SignInPageViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private DelegateCommand _signInCommand;
        private readonly Dictionary<string, string> _credentials;

        private string _login = "Admin";

        private string _password = "qwerty";

        public DelegateCommand SignInCommand =>
            _signInCommand ??= new DelegateCommand(OnCheckCredentials, CanCheckCredentials)
                               .ObservesProperty(() => Login)
                               .ObservesProperty(() => Password);

        public string Login
        {
            get => _login;
            set =>
                SetProperty(ref _login,
                            value,
                            nameof(Login));
        }

        public string Password
        {
            get => _password;
            set =>
                SetProperty(ref _password,
                            value,
                            nameof(Password));
        }

        public SignInPageViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _credentials = new Dictionary<string, string>
                           {
                               {
                                   ApplicationRoles.Administrator, "qwerty"
                               },
                               {
                                   ApplicationRoles.Manager, "qwerty1"
                               }
                           };
        }

        private bool CanCheckCredentials() => Login.Length > 3 && Password.Length > 4;

        private void OnCheckCredentials()
        {
            if (!_credentials.ContainsKey(Login))
            {
                MessageBox.Show("No users with this login",
                                "",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);

                return;
            }

            if (_credentials[Login] != Password)
            {
                MessageBox.Show("Not correct password",
                                "",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);

                return;
            }

            MessageBox.Show("Successful",
                            "",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);

            _eventAggregator.GetEvent<PubSubEvent<string>>().Publish(Login);
        }
    }
}
