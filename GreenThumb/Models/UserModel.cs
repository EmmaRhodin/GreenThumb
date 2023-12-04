using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    internal class UserModel
    {
        [Key]
        [Column("user_id")] public int UserId { get; set; }
        [Column("username")] public string Username { get; set; } = null!;
        [Column("password")] public string Password { get; set; } = null!;
        [Column("garden")] public virtual GardenModel? Garden { get; set; }
    }
}
