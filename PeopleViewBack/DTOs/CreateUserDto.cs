using System.ComponentModel.DataAnnotations;

namespace PeopleViewBack.DTOs
{
    public record CreateUserDto
    {
        [Required]
        public string FirstName { get; init; }
        [Required]
        public string LastName { get; init; }
        [Required]
        public string StreetName { get; init; }
        [Required]
        public string HouseNumber { get; init; }
        public string? ApartmentNumber { get; init; }
        [Required]
        public string PostalCode { get; init; }
        [Required]
        public string Town { get; init; }
        [Required]
        public string PhoneNumber { get; init; }
        [Required]
        public DateTime DateOfBirth { get; init; }
    }
}

