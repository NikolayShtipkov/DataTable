using System.ComponentModel.DataAnnotations;

namespace DataTable.DAL.Entities
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
