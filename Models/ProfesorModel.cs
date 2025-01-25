using System.ComponentModel.DataAnnotations;

namespace ExamenMVC.Models
{
    public class ProfesorModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        [EmailAddress]
        public string Correo { get; set; }
    }
}
