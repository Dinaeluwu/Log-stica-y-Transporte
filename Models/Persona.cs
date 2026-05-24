using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica_y_transporte.Models
{
    public class Persona
    {
        [Key]
        public Guid personaId { get; set; }

        [DisplayName("Nombres de Persona")]
        public string? Nombre { get; set; }

        [DisplayName ("Apellidos de Persona ")]
        public string? Apellido { get; set; }

        [DisplayName("Direccion persona")]
        public string? Direccion { get; set; }

        [ForeignKey("Id")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        [ScaffoldColumn(false)]
        public bool Inactivo {get; set; }
    }
}
