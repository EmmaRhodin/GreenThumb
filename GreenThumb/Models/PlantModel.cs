using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    internal class PlantModel
    {
        public PlantModel()
        {
            this.Gardens = new HashSet<GardenModel>();
        }

        [Key]
        [Column("id")] public int Id { get; set; }
        [Column("name")] public string Name { get; set; } = null!;
        [Column("botanical_name")] public string BotanicalName { get; set; } = null!;
        [Column("description")] public string? Description { get; set; }
        [Column("instruction")] public InstructionModel? Instruction { get; set; }
        [Column("garden")] public virtual ICollection<GardenModel> Gardens { get; set; }
    }
}
