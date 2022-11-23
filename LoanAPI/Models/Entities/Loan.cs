namespace LoanAPI.Models.Entities
{
    public class Loan // : Model
    {
        public int Id { get; set; } // Quitar esto luego de heredarlo de "Model"
        public int PersonId { get; set; }
        public int ThingId { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
