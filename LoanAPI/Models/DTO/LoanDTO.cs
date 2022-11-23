namespace LoanAPI.Models.DTO
{
    public class LoanDTO
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ThingId { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }

    }
}
