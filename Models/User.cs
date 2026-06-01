using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HdiBackend.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id_user")]
        public int IdUser { get; set; }
        [Column("id_type")]
        public int IdType { get; set; }
        [ForeignKey("IdType")]
        [JsonIgnore]
        public TypeUser TypeUser { get; set; } = null!;
        [Column("name")]
        public string Name { get; set; } = null!;
        [Column("tel")]
        public string? Tel { get; set; }
         [Column("username")]
        public string Username { get; set; } = string.Empty;
         [Column("password")]
        public string Password { get; set; } = string.Empty;

        public ICollection<Report> Reports { get; set; } = new List<Report>();
    }
}