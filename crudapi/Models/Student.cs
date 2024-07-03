using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudapi.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        [Column("StudentName" )]
        
        [MaxLength(50)]
        public string? Name { get; set; }
        [Column("Gender",TypeName ="varchar(50)")]
        
        public string? Gender { get; set; }
        
        public int? Age { get; set; }
    }
}
