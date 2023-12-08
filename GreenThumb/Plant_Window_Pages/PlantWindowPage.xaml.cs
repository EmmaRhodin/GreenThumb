using GreenThumb.Database;
using GreenThumb.Models;
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


        }

        private void btnSearch_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string input = txtbxSearch.Text;
            using (GreenThumbDbContext context = new())
            {
                PlantRepository<PlantModel> plantModel = new(context);
                lstOne.Items.Clear();
                var plantDisplay = plantModel.GetByBotanicalName(input);
                lstOne.ItemsSource = plantDisplay;
            }
        }
    }
}
