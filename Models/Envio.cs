using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica_y_transporte.Models
{
    public class Envio
    {
        [Key]
        [Column("id_envio")]
        public Guid id_envio { get; set; } = Guid.NewGuid();

        [Column("id_paquete")]
        public Guid? id_paquete { get; set; }

        [ForeignKey("id_paquete")]
        public Paquete? Paquete { get; set; }

        [Column("id_ruta")]
        public int? id_ruta { get; set; }

        [ForeignKey("id_ruta")]
        public Ruta? Ruta { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_envio { get; set; } = DateTime.UtcNow.Date;

        [Column(TypeName = "varchar(100)")]
        public string? estado { get; set; }
    }
}
