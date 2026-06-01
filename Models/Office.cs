using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HdiBackend.Models
{
    [Table("office")]
    public class Office
    {
        [Key]
        [Column("id_office")]
        public int IdOffice { get; set; }
        [Column("address")]
        public string Address { get; set; } = null!;
        public ICollection<Policy> Policies { get; set; } = new List<Policy>();
    }
}