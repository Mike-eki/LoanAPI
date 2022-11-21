namespace LoanAPI.Models.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ThingId { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Status { get; set; }

    }
}
