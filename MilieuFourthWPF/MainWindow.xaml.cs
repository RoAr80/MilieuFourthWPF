using System.Windows;
using System.Windows.Controls;

namespace MilieuFourthWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(SideNavigationMenuViewModel sideMenuVM, ApplicationWindowViewModel appVM)
        {
            InitializeComponent();

            SideNavigationMenuControl.DataContext = sideMenuVM;

            DataContext = appVM;            
        }       
    }
}
