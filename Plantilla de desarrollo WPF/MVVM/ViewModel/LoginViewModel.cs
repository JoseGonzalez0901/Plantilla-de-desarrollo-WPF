using Microsoft.EntityFrameworkCore;
using Plantilla_de_desarrollo_WPF.Core;
using Plantilla_de_desarrollo_WPF.DB_Clases;
using Plantilla_de_desarrollo_WPF.MVVM.View;
using System.Windows.Input;

namespace Plantilla_de_desarrollo_WPF.MVVM.ViewModel
{
    class LoginViewModel : ObservableObject
    {
        MainViewmodel _mainViewModel;
        private string _username;
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }
        public ICommand LoginCommand { get; }

        public ICommand RegisterCommand { get; }

        public LoginViewModel(MainViewmodel mainViewModel)
        {
            LoginCommand = new RelayCommand(ExecuteLogin);
            _mainViewModel = mainViewModel;
            RegisterCommand = new RelayCommand(o =>
            {
                _mainViewModel.CurrentView = _mainViewModel.RegisterViewModel;
            });
            
        }

        private void ExecuteLogin(object parameter)
        {


           if(Username == null || Password == null|| Username == "" || Password == "")
            {
                System.Windows.MessageBox.Show("Por favor, ingrese su usuario y contraseña.");
                return;
            }
           

            LoginDBService loginDBService = new LoginDBService();
            if(loginDBService.LoginUser(int.Parse(Username),Password))
            {
                _mainViewModel.CurrentView = _mainViewModel.LayoutViewModel;
            }

        }
    }
}
