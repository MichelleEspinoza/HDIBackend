namespace HdiBackend.DTOs
{
    public class CreatePolicyRequest
    {
        public string? PolicyNumber { get; set; }
        public string? LineOfBusiness { get; set; }
        public int IdOffice { get; set; } = 1;
        public string? PolicyHolder { get; set; }
        public string? Beneficiary { get; set; }
        public string? PaymentFrequency { get; set; } = "mensual";
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? IssueDate { get; set; }
        public string? VehicleInfo { get; set; }
        public bool? IsPaid { get; set; }
    }
}