using System.Windows;
using System.Windows.Controls;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        private void btnQuickLogIn_Click(object sender, RoutedEventArgs e)
        {
            // Fetch new instance of PlantWindow and open
            PlantWindow plantWindow = new PlantWindow();
            plantWindow.Show();

            // Close this window and pages
            CloseWindowFromPage();
        }

        /* I created a method to close the parent window from
           it's own page since it's a little different and can
           be re-used */
        public void CloseWindowFromPage()
        {
            var windowToClose = Window.GetWindow(this);
            if (windowToClose != null)
            {
                windowToClose.Close();
            }
        }
    }
}
