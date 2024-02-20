using System.ComponentModel.DataAnnotations;

namespace HMSBuinessObject.Model.RequestDto
{
    public class UpdateBookingReservationReqDto : IValidatableObject
    {
        [Required]
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }        
        public Guid? RoomId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? ActualPrice { get; set; }
        public string? Status { get; set; } = null!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate >= EndDate)
            {
                yield return new ValidationResult("StartDate must be less than EndDate.");
            }

            if ((CustomerId == null && RoomId == null) || (CustomerId != null && RoomId != null))
            {
                yield return new ValidationResult("Either CustomerId or RoomId must be provided, but not both.");
            }
        }
    }
}
