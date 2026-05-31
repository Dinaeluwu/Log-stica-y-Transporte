using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica_y_transporte.Models
{
    [Table("Facturas")]
    public class Factura
    {
        [Key]
        [Column("id_factura")]
        [ScaffoldColumn(false)]
        [Display(Name = "Número de factura", Order = 0)]
        public Guid id_factura { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Debe seleccionar un cliente.")]
        [Column("id_cliente")]
        [Display(Name = "Cliente", Order = 1)]
        public Guid id_cliente { get; set; }

        [ForeignKey(nameof(id_cliente))]
        [ScaffoldColumn(false)]
        public ClienteModels? Cliente { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un envío.")]
        [Column("id_envio")]
        [Display(Name = "Envío asociado", Order = 2)]
        public Guid id_envio { get; set; }

        [ForeignKey(nameof(id_envio))]
        [ScaffoldColumn(false)]
        public Envio? Envio { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, 999999999.99, ErrorMessage = "El monto debe ser mayor a cero.")]
        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Monto total", Prompt = "0.00", Order = 3)]
        public decimal monto { get; set; }

        [Required(ErrorMessage = "La fecha de la factura es obligatoria.")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de emisión", Order = 4)]
        public DateTime fechas { get; set; } = DateTime.UtcNow.Date;
    }
}
