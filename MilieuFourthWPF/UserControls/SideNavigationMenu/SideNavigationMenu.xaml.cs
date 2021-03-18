using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace MilieuFourthWPF
{
    /// <summary>
    /// Interaction logic for SideNavigationMenu.xaml
    /// </summary>
    public partial class SideNavigationMenu : UserControl
    {
        public SideNavigationMenu()
        {
            InitializeComponent();

            DataContext = new SideNavigationMenuViewModel();

            var mainWindow = DI.ServiceProvider.GetService<MainWindow>();

            mainWindow.SizeChanged += ChangeNavMenuSize;

            RerenderUserControl();
        }

        public HorizontalAlignment ControlsOnSmallSizeAlignment { get; set; } = HorizontalAlignment.Left;
        public Visibility ControlsOnSmallSizeVisibility { get; set; } = Visibility.Visible;
        public Visibility InvControlsOnSmallSizeVisibility
        {
            get
            {
                if (ControlsOnSmallSizeVisibility == Visibility.Visible)
                    return Visibility.Hidden;
                else
                    return Visibility.Visible;
            }
        }

        public Thickness IconMargin { get; set; } = new Thickness(10, 0, 0, 0);
        public Thickness UserProfileMargin { get; set; } = new Thickness(15, 0, 0, 0);
        public double SideMenuWidth { get; set; } = 205;
        public Style NavigationListViewStyle { get; set; } = (Style)App.Current.TryFindResource("NavigationListView");
        public Style ExitButtonStyle { get; set; } = (Style)App.Current.TryFindResource("ExitButton");

        // Величина, при которой окно считается маленьким по ширине
        private const int smallWidth = 1795;
        private void ChangeNavMenuSize(object sender, SizeChangedEventArgs e)
        {
            // Это длинное условие значит: если ширина предыдущая и новая ширина не превзошла
            // или не стала меньше величины маленького окна, то ничего не делай
            if ((e.PreviousSize.Width <= smallWidth && e.NewSize.Width <= smallWidth) ||
               (e.PreviousSize.Width > smallWidth && e.NewSize.Width > smallWidth))
                return;

            RerenderUserControl();
        }

        private void RerenderUserControl()
        {
            var mainWindow = DI.ServiceProvider.GetService<MainWindow>();

            if (mainWindow.ActualWidth <= smallWidth)
            {
                SideMenuWidth = 80;
                ControlsOnSmallSizeVisibility = Visibility.Collapsed;
                ControlsOnSmallSizeAlignment = HorizontalAlignment.Center;
                IconMargin = UserProfileMargin = new Thickness(0);
                NavigationListViewStyle = (Style)App.Current.TryFindResource("NavigationListViewSmall");
                ExitButtonStyle = (Style)App.Current.TryFindResource("ExitButtonFontAwesome");
            }
            else
            {
                SideMenuWidth = 205;
                ControlsOnSmallSizeVisibility = Visibility.Visible;
                ControlsOnSmallSizeAlignment = HorizontalAlignment.Left;
                IconMargin = new Thickness(10, 0, 0, 0);
                UserProfileMargin = new Thickness(15, 0, 0, 0);
                NavigationListViewStyle = (Style)App.Current.TryFindResource("NavigationListView");
                ExitButtonStyle = (Style)App.Current.TryFindResource("ExitButton");

            }

        }

        #region INotifyPropertyChanged Implementation

        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public void CallerPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
