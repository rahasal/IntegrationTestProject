using System.ComponentModel.DataAnnotations;

namespace RoomBookingApp.Domain.BaseModel
{
    public abstract class RoomBookingBase : IValidatableObject  // we dont want to anybody to be able to create an instance of room booking base
    {
        [Required]
        [StringLength(80)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [StringLength(80)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Date <= DateTime.Now.Date)
            {
                yield return new ValidationResult("Date Must be In The Future", new[] {nameof(Date)});
            }
        }
    }
}