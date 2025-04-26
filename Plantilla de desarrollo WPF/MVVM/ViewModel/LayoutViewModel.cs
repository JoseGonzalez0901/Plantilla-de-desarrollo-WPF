using Plantilla_de_desarrollo_WPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plantilla_de_desarrollo_WPF.MVVM.ViewModel
{
    class LayoutViewModel: ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }
        public HomeViewModel HomeViewModel { get; set; }
        public DiscoveryViewModel DiscoveryViewModel { get; set; }
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
        public LayoutViewModel()
        {
            HomeViewModel = new HomeViewModel();
            DiscoveryViewModel = new DiscoveryViewModel();
            CurrentView = HomeViewModel;
            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeViewModel;
            }
            );
            DiscoveryViewCommand = new RelayCommand(o =>
            {
                CurrentView = DiscoveryViewModel;
            }
            );
        }
    }
}
