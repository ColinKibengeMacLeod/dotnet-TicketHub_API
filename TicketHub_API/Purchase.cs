using System.ComponentModel.DataAnnotations;

namespace TicketHubAPI
{
    public class Purchase
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "ConcertId must be greater than 0.")]
        public int ConcertId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        // Payment Information
        [Required]
        [CreditCard(ErrorMessage = "Invalid credit card number.")]
        public string CreditCard { get; set; } = string.Empty;

        // For Expiration, you might want to enforce a MM/YY format.
        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$",
            ErrorMessage = "Expiration must be in MM/YY format.")]
        public string Expiration { get; set; } = string.Empty;

        [Required]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "Security code must be 3 or 4 digits.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Security code must be numeric.")]
        public string SecurityCode { get; set; } = string.Empty;

        // Address Information
        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string Province { get; set; } = string.Empty;

        // A sample regex for a Canadian postal code (adjust as needed for other regions)
        [Required]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z]\s?\d[A-Za-z]\d$",
            ErrorMessage = "Invalid postal code format.")]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        public string Country { get; set; } = string.Empty;
    }
}
