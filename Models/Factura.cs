using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica_y_transporte.Models
{
    public class Factura
    {
        [Key]
        [Column("id_factura")]
        public Guid id_factura { get; set; } = Guid.NewGuid();

        [Required]
        [Column("id_cliente")]
        public Guid id_cliente { get; set; }

        [ForeignKey("id_cliente")]
        public ClienteModels Cliente { get; set; } = null!;

        [Required]
        [Column("id_envio")]
        public Guid id_envio { get; set; }

        [ForeignKey("id_envio")]
        public Envio Envio { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayName("Monto")]
        public decimal monto { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DisplayName("Fecha")]
        public DateTime fechas { get; set; } = DateTime.UtcNow.Date;
    }
}
