using LoanAPI.IDTO;

namespace LoanAPI.Models.DTO
{
    public class PersonDTO : IBaseDTO
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

    }
}
