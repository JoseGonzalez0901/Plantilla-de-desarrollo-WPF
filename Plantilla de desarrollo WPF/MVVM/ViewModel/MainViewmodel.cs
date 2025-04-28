using Plantilla_de_desarrollo_WPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plantilla_de_desarrollo_WPF.MVVM.ViewModel
{
    class MainViewmodel:ObservableObject
    {
        public RelayCommand LoginViewCommand { get; set; }
        public RelayCommand LayoutViewCommand { get; set; }
        public RelayCommand RegiserViewCommand { get; set; }

        public RegisterViewModel RegisterViewModel { get; set; }
        public LoginViewModel LoginViewModel { get; set; }
        public LayoutViewModel LayoutViewModel { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewmodel()
        {
            LayoutViewModel = new LayoutViewModel();
            LoginViewModel = new LoginViewModel(this);
            RegisterViewModel = new RegisterViewModel(this);
            CurrentView = LoginViewModel;

            RegiserViewCommand = new RelayCommand(o =>
            {
                CurrentView = RegisterViewModel;
            });
            LoginViewCommand = new RelayCommand(o =>
            {
                CurrentView = LoginViewModel;
            }
            );
            LayoutViewCommand = new RelayCommand(o =>
            {
                CurrentView = LayoutViewModel;
            }
            );  
        }

        }
}

