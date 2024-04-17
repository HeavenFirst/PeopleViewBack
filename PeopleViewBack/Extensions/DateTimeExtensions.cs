namespace PeopleViewBack.Extensions
{
    public static class DateTimeExtensions
    {

        public static string? CalculateAge(this DateTime dateOfBirth)
        {

            if (dateOfBirth.Year == DateTime.UtcNow.Year)
            {
                return string.Empty;
            }

            var today = DateTime.Today;

            int age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age)) age--;

            return age.ToString();
        }
    }
}

