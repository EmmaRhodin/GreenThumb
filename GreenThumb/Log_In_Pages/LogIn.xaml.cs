using System.Windows;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();

            // Navigate to the Log In page on startup
            LogInPageNavigation.Content = new LogInPage();
        }

        private void btnGoToRegister_Click(object sender, RoutedEventArgs e)
        {
            // Changing visibility on the Register / Close button
            btnGoToRegister.Visibility = Visibility.Hidden;
            btnGoToLogIn.Visibility = Visibility.Visible;

            // Navigate to the Registration page
            LogInPageNavigation.Content = new RegisterPage();
        }

        private void btnGoToLogIn_Click(object sender, RoutedEventArgs e)
        {
            // Changing visibility on the Register / Close button
            btnGoToLogIn.Visibility = Visibility.Hidden;
            btnGoToRegister.Visibility = Visibility.Visible;

            // Navigate to the Log In page
            LogInPageNavigation.Content = new LogInPage();
        }
    }
}
