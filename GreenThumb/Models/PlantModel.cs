using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    internal class PlantModel
    {
        public PlantModel()
        {
        }

        [Key]
        [Column("id")] public int Id { get; set; }
        [Column("botanical_name")] public string? BotanicalName { get; set; }
        [Column("name")] public string Name { get; set; } = null!;
        [Column("description")] public string? Description { get; set; }
        public List<InstructionModel> Instruction { get; set; } = new();
    }
}
