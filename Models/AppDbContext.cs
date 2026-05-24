using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Logistica_y_transporte.Models
{
<<<<<<< HEAD

    public class AppDbContext :
=======
    //es para prueba
    //segunda prueba
    public class AppDbContext:
>>>>>>> 316a3b9e938b5013f3b54f52e5462fa9b4183824
        IdentityDbContext<IdentityUser>
    {
        public AppDbContext
            (DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Persona> Personas { get; set; }
    }
}
