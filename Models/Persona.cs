using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica_y_transporte.Models
{
    [Table("Personas")]
    public class Persona
    {
        [Key]
        [ScaffoldColumn(false)]
        [Display(Name = "Código de persona", Order = 0)]
        public Guid personaId { get; set; }

        [StringLength(100, ErrorMessage = "El nombre no puede superar {1} caracteres.")]
        [Display(Name = "Nombres", Prompt = "Ej: María", Order = 1)]
        public string? Nombre { get; set; }

        [StringLength(100, ErrorMessage = "El apellido no puede superar {1} caracteres.")]
        [Display(Name = "Apellidos", Prompt = "Ej: López García", Order = 2)]
        public string? Apellido { get; set; }

        [StringLength(250, ErrorMessage = "La dirección no puede superar {1} caracteres.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Dirección", Prompt = "Calle, zona, municipio", Order = 3)]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "Debe vincular un usuario del sistema.")]
        [ForeignKey(nameof(User))]
        [Display(Name = "Usuario del sistema", Order = 4)]
        public string? UserId { get; set; }

        [ScaffoldColumn(false)]
        public IdentityUser? User { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Inactivo")]
        public bool Inactivo { get; set; }
    }
}
