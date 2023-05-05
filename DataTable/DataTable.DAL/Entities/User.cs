using DataTable.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataTable.DAL.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public Role Role { get; set; }

        public bool isActive { get; set; }
    }
}