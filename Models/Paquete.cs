using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica_y_transporte.Models
{
    public class Paquete
    {
        [Key]
        [Column("ID_paquete")]
        public Guid ID_paquete { get; set; } = Guid.NewGuid();

        [Column("id_cliente")]
        public Guid id_cliente { get; set; }

        [ForeignKey("id_cliente")]
        public ClienteModels Cliente { get; set; } = null!;

        [Column(TypeName = "text")]
        public string? descripcion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal peso { get; set; }
    }
}
