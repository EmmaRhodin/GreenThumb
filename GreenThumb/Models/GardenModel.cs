using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    internal class GardenModel
    {
        public GardenModel()
        {
            this.Plants = new HashSet<PlantModel>();
        }
        [Key]
        [ForeignKey("user_id")] public int UserId { get; set; }
        [Required][Column("garden_id")] public int GardenId { get; set; }
        [Column("adress")] public string? Adress { get; set; }
        [Column("_user")] public virtual UserModel? User { get; set; }
        [Column("plants")] public virtual ICollection<PlantModel> Plants { get; set; }
    }
}
