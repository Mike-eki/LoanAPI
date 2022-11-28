using LoanAPI.IDTO;

namespace LoanAPI.Models.DTO
{
    public class CategoriesDTO : IBaseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

    }
}
