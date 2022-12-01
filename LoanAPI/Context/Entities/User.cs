using LoanAPI.Context.IEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Context.Entities
{
    public class User : IBaseEntity
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Column(Order = 1)]
        public string Username { get; set; }

        [Column(Order = 2)]
        public string Password { get; set; }

        [Column(Order = 3)]
        public string Name { get; set; }

        [Column(Order = 4)]
        public string Email { get; set; }

        [Column(Order = 5)]
        public string Role { get; set; }

        [Column(Order = 6)]
        public DateTime CreationTime { get; set; }
    }
}
