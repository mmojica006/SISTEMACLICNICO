namespace CLINICAL.Domain.Entities
{
    public class Patient
    {
        public int? PatientId { get; set; }
        public string? Names { get; set; }
        public string? LastName { get; set; }
        public string? MotherMaidenName { get; set; }
        public int? DocumentTypeId { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Phone { get; set; }
        public int? TypeAgeId { get; set; }
        public int? Age { get; set; }
        public int? GenderId { get; set; }
        public int? State { get; set; }
        public DateTime? AuditCreateDate { get; set; }

        // Navigation properties
        public DocumentType DocumentType { get; set; }
        public TypeAge TypeAge { get; set; }
        public Gender Gender { get; set; }
    }

}
