using LoanAPI.Context.IEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Models.Entities
{
    public class Loan : IBaseEntity
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 1)]
        public DateTime Date { get; set; }

        [Required]
        [Column(Order = 2)]
        public bool Status { get; set; }

        [Required]
        [ForeignKey("BorrowerPerson")]
        [Column(Order = 3)]
        public int PersonId { get; set; }
        public Person BorrowerPerson { get; set; }

        [Required]
        [ForeignKey("BorrowedThing")]
        [Column(Order = 4)]
        public int ThingId { get; set; }
        public Thing BorrowedThing { get; set; }

        [Column(Order = 5)]
        public DateTime CreationTime { get; set; }

    }
}
