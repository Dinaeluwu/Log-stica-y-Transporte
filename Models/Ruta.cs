using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica_y_transporte.Models
{
    [Table("Rutas")]
    public class Ruta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_ruta")]
        [ScaffoldColumn(false)]
        [Display(Name = "Código de ruta", Order = 0)]
        public int id_ruta { get; set; }

        [Required(ErrorMessage = "La zona de la ruta es obligatoria.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "La zona debe tener entre {2} y {1} caracteres.")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Zona de cobertura", Prompt = "Ej: Zona Norte - Ciudad", Order = 1)]
        public string zona { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del piloto es obligatorio.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El piloto debe tener entre {2} y {1} caracteres.")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Piloto asignado", Prompt = "Ej: Juan Pérez", Order = 2)]
        public string piloto { get; set; } = string.Empty;
    }
}
