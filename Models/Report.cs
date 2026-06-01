using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HdiBackend.Models
{
    [Table("report")]
    public class Report
    {
        [Key]
        [Column("id_report")]
        public int IdReport { get; set; }
        [Column("id_office")]
        public int IdOffice { get; set; }
        [Column("policy_number")]
        public string PolicyNumber { get; set; } = null!;
        public Policy Policy { get; set; } = null!; 
        [Column("date_time")]
        public DateTime DateTime { get; set; }
        [Column("location")]
        public string Location { get; set; } = null!;
        [Column("reporter_name")]
        public string ReporterName { get; set; } = null!;
        [Column("reporter_phone")]
        public string ReporterPhone { get; set; } = null!;
        [Column("email")]
        public string Email { get; set; } = null!;
        [Column("description")]
        public string Description { get; set; } = null!;
        [Column("license_plate")]
        public string LicensePlate { get; set; } = null!;
        [Column("color")]
        public string Color { get; set; } = null!;
        [Column("notes")]
        public string? Notes { get; set; }
        [Column("id_user")]
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User Adjuster { get; set; } = null!;
    }
}