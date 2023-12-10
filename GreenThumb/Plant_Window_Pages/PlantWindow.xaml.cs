using GreenThumb.Plant_Window_Pages;
using System.Windows;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for PlantWindow.xaml
    /// </summary>
    public partial class PlantWindow : Window
    {
        public PlantWindow()
        {
            InitializeComponent();

            // Navigate to the PlantWindow page on startup
            PlantPageNavigation.Content = new PlantWindowPage();
        }

        // TODO METHOD FOR GETTING USERNAME

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }

        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {
            PlantPageNavigation.Content = new AddPlantPage();
        }

        private void btnPlantWindow_Click(object sender, RoutedEventArgs e)
        {
            PlantPageNavigation.Content = new PlantWindowPage();
        }

        private void btnMyGarden_Click(object sender, RoutedEventArgs e)
        {
            PlantPageNavigation.Content = new MyGardenPage();
        }
    }
}
