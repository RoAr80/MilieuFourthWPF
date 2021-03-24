using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace MilieuFourthWPF
{
    /// <summary>
    /// Interaction logic for LoginAndRegPage.xaml
    /// </summary>
    public partial class LoginAndRegPage : UserControl
    {
        public LoginAndRegPage()
        {
            InitializeComponent();

            DataContext = new LoginAndRegViewModel();
        }

        public LoginAndRegPage(LoginAndRegViewModel datacontext)
        {
            InitializeComponent();

            DataContext = datacontext;
        }

        private void MainGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainGrid.Focus();            
        }

        //Флаг покажет анимируется ли сейчас форма
        private bool isFormInAnimation = false;

        private void MoveToLogRegPageButton(object sender, RoutedEventArgs e)
        {
            if (isFormInAnimation)
                return;

            Border currentBorder;
            Border nextBorder;

            float animationDurationInSec = 0.6f;

            if (LoginFormBorder.Visibility == Visibility.Visible)
            {
                currentBorder = LoginFormBorder;
                nextBorder = RegistrationFormBorder;
            }
            else
            {
                currentBorder = RegistrationFormBorder;
                nextBorder = LoginFormBorder;
            }

            var currentSb = new Storyboard();
            currentSb.AddSlideToLeft(animationDurationInSec, currentBorder.ActualWidth);
            currentSb.AddFadeOut(animationDurationInSec);            
            currentSb.Completed += (o, s) => currentBorder.Visibility = Visibility.Hidden;

            var nextSb = new Storyboard();
            nextSb.AddSlideFromRight(animationDurationInSec, nextBorder.ActualWidth + 50);
            nextSb.AddFadeIn(animationDurationInSec);
            nextSb.Completed += (o, s) => isFormInAnimation = false ;
            nextBorder.Visibility = Visibility.Visible;

            isFormInAnimation = true;
            currentSb.Begin(currentBorder);
            nextSb.Begin(nextBorder);
            
        }
        

        private void PasswordRegistration_Changed(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).PasswordRegistration = ((PasswordBox)sender).SecurePassword; }
        }

        private void ConfirmPasswordRegistration_Changed(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).ConfirmPasswordRegistration = ((PasswordBox)sender).SecurePassword; }
        }

        private void PasswordLogin_Changed(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).PasswordLogin = ((PasswordBox)sender).SecurePassword; }
        }
    }
}
