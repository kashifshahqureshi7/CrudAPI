using Microsoft.EntityFrameworkCore;

namespace crudapi.Models
{
    public class StudentDBContext :DbContext
    {
        public StudentDBContext(DbContextOptions options): base(options)
        {
                
        }
        public DbSet<Student> Students { get; set; } //ye table ko represent karny k liye use hota hy matlab database jo table create hoga oska name automatic students ayega 

    }
}
