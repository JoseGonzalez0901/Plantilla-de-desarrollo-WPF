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

        public LoginViewModel(MainViewmodel mainViewModel)
        {
            LoginCommand = new RelayCommand(ExecuteLogin);
            _mainViewModel = mainViewModel;
        }

        private void ExecuteLogin(object parameter)
        {
            AppDbContext context = new AppDbContext();
            DatabaseManager<LoginDBService> dbManager = new DatabaseManager<LoginDBService>(context);

           if(Username == null || Password == null)
            {
                System.Windows.MessageBox.Show("Por favor, ingrese su usuario y contraseña.");
                return;
            }
            LoginDBService user = dbManager.GetById(int.Parse(Username));

            // Aquí puedes poner lógica real de autenticación
            if(user==null)
            {
                System.Windows.MessageBox.Show("Usuario no encontrado");
                return;
            }
            else if (user.Clave == Password)
            {
                _mainViewModel.CurrentView = _mainViewModel.LayoutViewModel;
            }
            else
            {
                // Aquí puedes mostrar un mensaje de error o realizar alguna acción si la autenticación falla
                System.Windows.MessageBox.Show("Contraseña incorrecta");
            }
        }
    }
}
