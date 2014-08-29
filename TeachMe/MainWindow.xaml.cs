using TeachMe.viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TeachMe
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //MOOCAutoSnailEscritorio.viewmodels.NavigationViewModel.Instance.CurrentPage.DataContext = new CategoriaViewModel();
            //TeachMe.viewmodels
            InitializeComponent();
            DataContext = NavigationViewModel.Instance;
            NavigationViewModel.Instance.CurrentFrameNav = frameBotonera;
            //TeachMe.viewmodels.NavigationViewModel.Instance.CurrentPage.DataContext = new verbosViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Close App
            Application.Current.Shutdown();
        }
    }
}
