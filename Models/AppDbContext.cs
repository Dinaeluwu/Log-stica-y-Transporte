using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Logistica_y_transporte.Models
{
    //Base de datos principal
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        //Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //Tabla de persona de la base de datos
        public DbSet<Persona> Personas { get; set; }
    }
}