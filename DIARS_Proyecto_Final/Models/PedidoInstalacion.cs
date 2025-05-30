using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIARS_Proyecto_Final.Models
{
    [Table("PedidoInstalacion")]
    public class PedidoInstalacion
    {
        [Key]
        [Column("pedido_id")]
        public int pedido_id { get; set; }

        [Required]
        [Column("contrato_id")]
        public int contrato_id { get; set; }

        [Required]
        [Column("empleado_id")]
        public int empleado_id { get; set; }

        [Column("fecha_instalacion")]
        public DateTime? fecha_instalacion { get; set; }

        [Column("estado_instalacion")]
        [StringLength(20)]
        public string estado_instalacion { get; set; }

        [Column("observaciones")]
        [StringLength(255)]
        public string observaciones { get; set; }
    }
}
