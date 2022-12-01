using LoanAPI.Context.IEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Context.Entities
{
    public class Thing : IBaseEntity
    {
        [Key]
        [InverseProperty("BorrowedThing")]
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Categories Category { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
