using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    internal class InstructionModel
    {
        [Column("id")] public int Id { get; set; }
        [Column("instruction")] public string? Instruction { get; set; }
        [Column("plant_id")] public int? PlantId { get; set; }
        public PlantModel? Plant { get; set; }
    }
}
