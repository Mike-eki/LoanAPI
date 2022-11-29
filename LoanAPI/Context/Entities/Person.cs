using LoanAPI.Context.IEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LoanAPI.Context;

namespace LoanAPI.Models.Entities
{
    public class Person : IBaseEntity
    {

        [Key]
        [InverseProperty("BorrowerPerson")]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
        public string Name { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public DateTime CreationTime { get; set; }
    }

}
