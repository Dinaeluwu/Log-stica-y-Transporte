using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica_y_transporte.Models
{
    public class ClienteModels
    {
        [Key]
        [Column("Id_Cliente")]
        public Guid Id_Cliente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "varchar(150)")]
        public string? nombre { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? nit { get; set; }
    }
}

//PRUEBA DE CAMBIO EN GITHUB 2026 HORA 10:57.
//segunda prueba de cambio en github 2026 HORA 11:00.

// prueba de cambios