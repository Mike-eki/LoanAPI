using LoanAPI.IDTO;

namespace LoanAPI.Models.DTO
{
    public class LoanDTO : IBaseDTO
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ThingId { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }

    }
}
