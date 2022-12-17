namespace eCommerce.Domain.Common
{
    public abstract class AuditableEntity
    {
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsRemoved { get; set; } = false;
    }
}