using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Logistica_y_transporte.Models
{
    //es para prueba
    //segunda prueba
    public class AppDbContext:
        IdentityDbContext<IdentityUser>
    {
        public AppDbContext 
            (DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
    }
}
