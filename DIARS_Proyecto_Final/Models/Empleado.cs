using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; 
namespace DIARS_Proyecto_Final.Models
{
    public class Empleado
    {
        [Key] 
        public int empleado_id { get; set; }

        [Required(ErrorMessage = "El cargo es obligatorio.")]
        public int cargo_id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string nombres { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio.")]
        public string dni { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
        public string correo { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string password { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public string estado { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateTime? fecha_inicio { get; set; }

        public DateTime? fecha_fin { get; set; }

        [ForeignKey("cargo_id")] 
        public Cargo Cargo { get; set; }
    }
}
