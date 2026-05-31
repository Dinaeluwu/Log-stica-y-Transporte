using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica_y_transporte.Models
{
    [Table("Envios")]
    public class Envio
    {
        [Key]
        [Column("id_envio")]
        [ScaffoldColumn(false)]
        [Display(Name = "Código de envío", Order = 0)]
        public Guid id_envio { get; set; } = Guid.NewGuid();

        [Column("id_paquete")]
        [Display(Name = "Paquete", Description = "Opcional si el envío aún no tiene paquete asignado.", Order = 1)]
        public Guid? id_paquete { get; set; }

        [ForeignKey(nameof(id_paquete))]
        [ScaffoldColumn(false)]
        public Paquete? Paquete { get; set; }

        [Column("id_ruta")]
        [Display(Name = "Ruta", Description = "Opcional si la ruta se asigna después.", Order = 2)]
        public int? id_ruta { get; set; }

        [ForeignKey(nameof(id_ruta))]
        [ScaffoldColumn(false)]
        public Ruta? Ruta { get; set; }

        [Required(ErrorMessage = "La fecha de envío es obligatoria.")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de envío", Order = 3)]
        public DateTime fecha_envio { get; set; } = DateTime.UtcNow.Date;

        [StringLength(100, ErrorMessage = "El estado no puede superar {1} caracteres.")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Estado del envío", Prompt = "Ej: En tránsito, Entregado, Pendiente", Order = 4)]
        public string? estado { get; set; }
    }
}
