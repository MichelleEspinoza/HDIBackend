using System.ComponentModel.DataAnnotations.Schema;

namespace HdiBackend.Models
{
    [Table("policy")]
    public class Policy
    {

        [Column("id_office")]
        public int IdOffice { get; set; }
        [ForeignKey("IdOffice")]
        public Office? Office { get; set; }
        [Column("policy_number")]    
        public string PolicyNumber { get; set; } = null!;
        [Column("line_of_business")]    
        public string? LineOfBusiness { get; set; }
        [Column("policy_holder")]  
        public string PolicyHolder { get; set; } = null!;
        [Column("beneficiary")]  
        public string Beneficiary { get; set; } = null!;
        [Column("start_date")]  
        public DateTime StartDate { get; set; }
        [Column("end_date")]  
        public DateTime EndDate { get; set; }
        [Column("issue_date")]
        public DateTime IssueDate { get; set; }
        [Column("payment_frequency")]
        public string PaymentFrequency { get; set; } = null!;
        [Column("vehicle_info")]
        public string? VehicleInfo { get; set; }
        [Column("is_paid")]
        public bool IsPaid { get; set; }
        public ICollection<Report> Reports { get; set; } = new List<Report>();
    }
}