namespace MicroBookShop.Services.CouponAPI.Domain.Entities.Common
{
    /// <summary>
    /// Base entity for all models
    /// </summary>
    public class AuditableEntity
    {
        public int Id { get; set; }

        public DateTime CreateAt { get; set; }

        public string CreatedBy { get; set; }

        public string? EditedBy { get; set; }

        public DateTime EditedAt { get; set; }

        public bool? IsDeleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime DeletedAt { get; set; }

        public int StatusId { get; set; } 
    }
}
