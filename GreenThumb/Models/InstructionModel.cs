using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    internal class InstructionModel
    {
        [Column("instruction_id")] public int Id { get; set; }
        [Column("instruction")] public string? Instruction { get; set; }
        [Column("plants")] public List<PlantModel> Plants { get; set; } = new();
    }
}
