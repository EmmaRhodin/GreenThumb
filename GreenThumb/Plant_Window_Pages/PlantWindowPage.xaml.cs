using GreenThumb.Database;
using GreenThumb.Models;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb.Plant_Window_Pages
{
    /// <summary>
    /// Interaction logic for PlantWindowPage.xaml
    /// </summary>
    public partial class PlantWindowPage : Page
    {
        public PlantWindowPage()
        {
            InitializeComponent();

            using (GreenThumbDbContext context = new())
            {
                PlantRepository<PlantModel> plantModel = new(context);
                var initialPlantDisplay = plantModel.GetAll();
                lstOne.ItemsSource = initialPlantDisplay;
            }
        }
        private void txtbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = txtbxSearch.Text;
            using (GreenThumbDbContext context = new())
            {
                PlantRepository<PlantModel> plantModel = new(context);
                var plantDisplay = plantModel.GetByPlantName(input);
                lstOne.ItemsSource = plantDisplay;
            }
        }
        private MessageBoxResult ErrorNoPlantSelection()
        {
            return MessageBox.Show("Error: No plant selected!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
        }

        private void btnDetails_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (lstOne.SelectedItem == null)
            {
                ErrorNoPlantSelection();
            }
            else
            {
                // Selecta plantan från listan
                var selectedPlant = lstOne.SelectedItem as PlantModel;

                // Hämta instans av PlantWindow för att kunda använda page navigering
                PlantWindow plantWindow = Window.GetWindow(this) as PlantWindow;
                if (plantWindow != null)
                {
                    plantWindow.PlantPageNavigation.Navigate(new PlantDetailsPage(selectedPlant));
                }
            }
        }

        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (lstOne.SelectedItem == null)
            {
                ErrorNoPlantSelection();
            }
            else
            {
                var selectedPlant = lstOne.SelectedItem as PlantModel;

                using (GreenThumbDbContext context = new())
                {
                    PlantRepository<PlantModel> plantModel = new(context);

                    plantModel.Delete(selectedPlant.Id);
                    var updateDisplay = plantModel.GetAll();
                    lstOne.ItemsSource = updateDisplay;
                }
            }
        }
    }
}
