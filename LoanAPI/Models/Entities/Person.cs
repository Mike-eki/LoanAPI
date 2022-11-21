namespace LoanAPI.Models.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
