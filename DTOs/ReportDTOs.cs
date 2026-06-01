namespace HdiBackend.DTOs
{
    public class CreateReportRequest
    {
        public int? IdOffice { get; set; }
        public string? PolicyNumber { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Location { get; set; }
        public string? ReporterName { get; set; }
        public string? ReporterPhone { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public string? LicensePlate { get; set; }
        public string? Color { get; set; }
        public string? Notes { get; set; }
        public int IdUser { get; set; }
        public string? Adjuster { get; set; }
    }
}