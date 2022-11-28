using LoanAPI.IDTO;

namespace LoanAPI.Models.DTO
{
    public class ThingDTO : IBaseDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

    }
}
