using Plantilla_de_desarrollo_WPF.Core;
using Plantilla_de_desarrollo_WPF.DB_Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Plantilla_de_desarrollo_WPF.MVVM.ViewModel
{
    
    class RegisterViewModel:ObservableObject
    {
        MainViewmodel _mainViewModel;
        private string _username;
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }
        private string _Confirm_Password;
        public string Confirm_Password
        {
            get => _Confirm_Password;
            set { _Confirm_Password = value; OnPropertyChanged(); }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }
        public int _ID_Empleado;
        public int ID_Empleado
        {
            get => _ID_Empleado;
            set { _ID_Empleado = value; OnPropertyChanged(); }
        }
        public ICommand RegisterCommand { get; }

        public ICommand LoginCommand { get; }

        LoginViewModel loginViewModel;
        public RegisterViewModel(MainViewmodel mainViewmodel)
        {
            RegisterCommand = new RelayCommand(ExecuteRegister);
            _mainViewModel = mainViewmodel;
            LoginCommand = new RelayCommand(BackLogin);

           
        }
        private void BackLogin(object parameter)
        {
            _mainViewModel.CurrentView = _mainViewModel.LoginViewModel;
        }
        private void ExecuteRegister(object parameter)
        {
            LoginDBService dBService = new LoginDBService();
            dBService.ID_Empleado = ID_Empleado;
            dBService.Usuario = Username;
            dBService.Clave = Password;
            if (Username == null || Password == null || Confirm_Password == null || Username == "" || Password == "" || Confirm_Password == "")
            {
                System.Windows.MessageBox.Show("Por favor, ingrese su usuario y contraseña.");
                return;
            }
            if (Password != Confirm_Password)
            {
                System.Windows.MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }
            dBService.Register_user(dBService);

        }



    }
}
