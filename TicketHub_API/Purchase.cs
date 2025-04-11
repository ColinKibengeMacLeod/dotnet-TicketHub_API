using System.ComponentModel.DataAnnotations;

namespace TicketHubAPI
{
    public class Purchase
    {
        //TO-DO: Validation Testing on all properties
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "ConcertId must be greater than 0.")]
        public int ConcertId { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Full name is required")]
        [MaxLength(50, ErrorMessage = "Full name must be less than 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [MaxLength(16, ErrorMessage = "Phone number must be 16 characters")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "A quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        // Removed invalid MaxLength from int
        public int Quantity { get; set; }

        // Payment Information
        [Required(ErrorMessage = "A valid credit card is required")]
        [CreditCard(ErrorMessage = "Invalid credit card number.")]
        public string CreditCard { get; set; } = string.Empty;

        // For Expiration, enforce MM/YY format
        [Required(ErrorMessage = "An valid credit card expiration date is required")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Expiration must be in MM/YY format.")]
        [MaxLength(5)]
        public string Expiration { get; set; } = string.Empty;

        [Required(ErrorMessage = "A valid credit card security code is required")]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "Security code must be 3 or 4 digits.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Security code must be numeric.")]
        public string SecurityCode { get; set; } = string.Empty;

        // Address Information
        [Required(ErrorMessage = "A valid address is required")]
        [MaxLength(25, ErrorMessage = "Address must be less than 25 characters")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "A valid city name is required")]
        [MaxLength(25, ErrorMessage = "City name must be less than 25 characters")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "A province or territory name is required")]
        [MaxLength(25, ErrorMessage = "Province or territory name must be less than 25 characters")]
        public string Province { get; set; } = string.Empty;

        // Canadian postal code pattern
        [Required(ErrorMessage = "A valid postal code is required")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z]\s?\d[A-Za-z]\d$", ErrorMessage = "Invalid postal code format.")]
        [MaxLength(7)]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "A country name is required")]
        [MaxLength(25, ErrorMessage = "Country name must be less than 25 characters")]
        public string Country { get; set; } = string.Empty;
    }
}
