using System.Windows;
using System.Windows.Controls;

namespace MilieuFourthWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ApplicationWindowViewModel appVM)
        {
            InitializeComponent();

            DataContext = appVM;            
        }       
    }
}
