using DataTable.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataTable.WEB.Models
{
    public class UserModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public Role Role { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
