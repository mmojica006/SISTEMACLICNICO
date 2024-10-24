namespace CLINICAL.Application.Dtos.Medic
{
    public class GetAllMedicResponseDto
    {
        public int? MedicId { get; set; }
        public string? Names { get; set; }
        public string? Surnames { get; set; }
        public string? Specialty { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? BirthDate { get; set; }
        public string? State { get; set; }
        public string? MedicAudit { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
