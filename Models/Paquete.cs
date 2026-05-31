using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica_y_transporte.Models
{
    [Table("Paquetes")]
    public class Paquete
    {
        [Key]
        [Column("ID_paquete")]
        [ScaffoldColumn(false)]
        [Display(Name = "Código de paquete", Order = 0)]
        public Guid ID_paquete { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Debe seleccionar un cliente.")]
        [Column("id_cliente")]
        [Display(Name = "Cliente", Order = 1)]
        public Guid id_cliente { get; set; }

        [ForeignKey(nameof(id_cliente))]
        [ScaffoldColumn(false)]
        public ClienteModels? Cliente { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede superar {1} caracteres.")]
        [Column(TypeName = "text")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción del contenido", Prompt = "Ej: Cajas de repuestos, frágil", Order = 2)]
        public string? descripcion { get; set; }

        [Required(ErrorMessage = "El peso es obligatorio.")]
        [Range(0.01, 99999.99, ErrorMessage = "El peso debe estar entre {1} y {2} kg.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:N2} kg", ApplyFormatInEditMode = true)]
        [Display(Name = "Peso (kg)", Prompt = "0.00", Order = 3)]
        public decimal peso { get; set; }
    }
}
