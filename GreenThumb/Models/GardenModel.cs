using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    internal class GardenModel
    {
        public GardenModel()
        {
            this.Plants = new HashSet<PlantModel>();
        }
        [ForeignKey("user")] public int GardenId { get; set; }
        [Column("adress")] public string? Adress { get; set; }
        public virtual UserModel? User { get; set; }
        public virtual ICollection<PlantModel> Plants { get; set; }
    }
}
