using LoanAPI.Context.IEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Models.Entities
{
    public class Categories : IBaseEntity
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
        [Column(Order = 1)]
        public string Name { get; set; }

        [StringLength(255)]
        [Column(Order = 2)]
        public string? Description { get; set; }

        [Column(Order = 3)]
        public DateTime CreationTime { get; set; }

    }
}
