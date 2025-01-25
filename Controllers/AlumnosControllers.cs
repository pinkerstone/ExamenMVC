using Microsoft.AspNetCore.Mvc;
using Services;
using ExamenMVC.Models;
using Domain;
using Infraestructure;

namespace ExamenMVC.Controllers
{
    public class AlumnosControllers : Controller
    {
        public IActionResult Index()
        {
            
            AlumnoService service = new AlumnoService();

            var alumnos = service.Get();

            var model = alumnos.Select(x => new AlumnoModel
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Correo = x.Correo,
                FechaNacimiento = x.FechaNacimiento,
            }).ToList();

            return View(model);
        }
    }
}
