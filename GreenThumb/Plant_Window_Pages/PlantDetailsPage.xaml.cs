using GreenThumb.Database;
using GreenThumb.Models;
using System.Windows.Controls;

namespace GreenThumb.Plant_Window_Pages
{
    /// <summary>
    /// Interaction logic for PlantDetailsPage.xaml
    /// </summary>
    public partial class PlantDetailsPage : Page
    {
        public PlantDetailsPage(object plantObject)
        {
            InitializeComponent();

            if (plantObject != null && plantObject is PlantModel)
            {
                PlantModel plant = (PlantModel)plantObject;
                txtbxPlantName.Text = plant.Name;
                txtbxLatinName.Text = plant.BotanicalName;

                int PlantId = plant.Id;
                using (GreenThumbDbContext context = new())
                {
                    PlantRepository<InstructionModel> instructionModel = new(context);
                    var instructionDisplay = instructionModel.GetAllInstructions(PlantId);
                    var instructionText = string.Join(Environment.NewLine, instructionDisplay.Select(s => s.Instruction));
                    txtbxInstructions.Text = instructionText;
                }
            }
        }
    }
}
