using System.ComponentModel.DataAnnotations;

namespace ExamenMVC.Models
{
    public class AlumnoModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [EmailAddress]
        public string Correo { get; set; }
    }
}
