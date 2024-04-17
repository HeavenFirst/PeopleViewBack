using PeopleViewBack.Extensions;

namespace PeopleViewBack.DTOs
{
    public record GetUserDto
    {
        public long Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string StreetName { get; init; }
        public string HouseNumber { get; init; }
        public string? ApartmentNumber { get; init; }
        public string PostalCode { get; init; }
        public string Town { get; init; }
        public string PhoneNumber { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string? Age { get => DateOfBirth.CalculateAge(); }

    }
}