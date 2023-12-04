using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    internal class InstructionModel
    {
        [Column("id")] public int Id { get; set; }
        [Column("instruction")] public string? Instruction { get; set; }
        public List<PlantModel> Plants { get; set; } = new();
    }
}
