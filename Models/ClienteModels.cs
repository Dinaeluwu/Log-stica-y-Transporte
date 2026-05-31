using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica_y_transporte.Models
{
    [Table("Clientes")]
    public class ClienteModels
    {
        [Key]
        [Column("Id_Cliente")]
        [ScaffoldColumn(false)]
        [Display(Name = "Código de cliente", Order = 0)]
        public Guid Id_Cliente { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [StringLength(150, ErrorMessage = "El nombre no puede superar {1} caracteres.")]
        [Column(TypeName = "varchar(150)")]
        [Display(Name = "Nombre o razón social", Prompt = "Ej: Logística Express S.A.", Order = 1)]
        public string? nombre { get; set; }

        [StringLength(50, ErrorMessage = "El NIT no puede superar {1} caracteres.")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "NIT", Prompt = "Ej: 1234567-8", Order = 2)]
        [RegularExpression(@"^[\dA-Za-z\-]+$", ErrorMessage = "El NIT solo puede contener números, letras y guiones.")]
        public string? nit { get; set; }
    }
}
