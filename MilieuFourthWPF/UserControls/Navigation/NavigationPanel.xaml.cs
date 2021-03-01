using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MilieuFourthWPF
{
    /// <summary>
    /// Interaction logic for NavigationPanel.xaml
    /// </summary>
    public partial class NavigationPanel : UserControl
    {
        public NavigationPanel()
        {
            InitializeComponent();

            //test
            DataContext = this;
            List<string> arr = new List<string> { "Главная", "Карточки", "Статистика", "Настройки", "Магазин" };
            lvDataBinding.ItemsSource = arr;
            
        }

        
    }
}
