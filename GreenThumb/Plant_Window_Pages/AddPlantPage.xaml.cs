using GreenThumb.Database;
using GreenThumb.Models;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb.Plant_Window_Pages
{
    /// <summary>
    /// Interaction logic for AddPlantPage.xaml
    /// </summary>
    public partial class AddPlantPage : Page
    {
        private List<string> instructionList = new List<string>();
        public AddPlantPage()
        {
            InitializeComponent();
        }

        private void btnAddInstruction_Click(object sender, RoutedEventArgs e)
        {
            string instructionToAdd = txtbxInstructions.Text;

            if (instructionToAdd != null && instructionToAdd.Length > 0)
            {
                instructionList.Add(instructionToAdd);

                // gör den snabbt ItemsSource null och sedan instructionList så att lstInstructions uppdateras
                lstInstructions.ItemsSource = null;
                lstInstructions.ItemsSource = instructionList;
                txtbxInstructions.Clear();
            }
        }

        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {
            string nameToCheck = txtbxLatinName.Text.Trim();
            bool doesNameExist = checkIfBotanicalNameExists(nameToCheck);

            if (txtbxPlantName.Text == null || txtbxPlantName.Text.Length < 5)
            {
                MessageBox.Show("Error: Plant name has to be longer than 4 characters!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            else if (!Regex.IsMatch(txtbxPlantName.Text, "^[A-Za-z ]+$"))
            {
                MessageBox.Show("Error: Only english letters and spaces allowed for names!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);

            }
            else if (txtbxLatinName.Text == null || txtbxLatinName.Text.Length < 5)
            {
                MessageBox.Show("Error: Latin name has to be longer than 4 characters!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            else if (!Regex.IsMatch(txtbxLatinName.Text, "^[A-Za-z ]+$"))
            {
                MessageBox.Show("Error: Only english letters and spaces allowed for names!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }

            // Jag använder det latinska namnet på växter som min Primary Key eftersom det kan finnas
            // arter som delar samma svenska namn, till exempel olika maskrosor!
            else if (doesNameExist)
            {
                MessageBox.Show("Error: This plant already exists in the database!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            else
            {
                using (var dbContext = new GreenThumbDbContext())
                {
                    var newPlant = new PlantModel
                    {
                        Name = txtbxPlantName.Text,
                        BotanicalName = txtbxLatinName.Text,
                        Description = txtbxDescription.Text,
                    };
                    dbContext.Plants.Add(newPlant);
                    dbContext.SaveChanges();

                    int getIdOfThePlant = newPlant.Id;

                    foreach (var instruction in instructionList)
                    {
                        var newInstruction = new InstructionModel
                        {
                            Instruction = instruction,
                            PlantId = getIdOfThePlant,
                        };
                        dbContext.Instructions.Add(newInstruction);
                    }
                    dbContext.SaveChanges();

                    PlantWindow plantWindow = Window.GetWindow(this) as PlantWindow;
                    if (plantWindow != null)
                    {
                        plantWindow.PlantPageNavigation.Navigate(new PlantWindowPage());
                    }
                }
            }

        }

        private void btnDeleteInstruction_Click(object sender, RoutedEventArgs e)
        {
            if (lstInstructions.SelectedItems != null)
            {
                instructionList.Remove(lstInstructions.SelectedItem.ToString());
                lstInstructions.ItemsSource = null;
                lstInstructions.ItemsSource = instructionList;
            }
        }

        private bool checkIfBotanicalNameExists(string botanicalName)
        {
            using (var dbContext = new GreenThumbDbContext())
            {
                return dbContext.Plants.Any(p => p.BotanicalName == botanicalName);
            }
        }
    }
}
