namespace LoanAPI.Models.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
