using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HdiBackend.Models
{
    [Table("type_user")]
    public class TypeUser
    {
        [Key]
        [Column("id_type")]
        public int IdType { get; set; }
        [Column("type")]
        public string Type { get; set; } = null!;

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}