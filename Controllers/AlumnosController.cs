using Microsoft.AspNetCore.Mvc;
using Services;
using ExamenMVC.Models;
using Domain;
using Infraestructure;

namespace ExamenMVC.Controllers
{
    public class AlumnosController : Controller
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AlumnoModel model)
        {
            if (ModelState.IsValid)
            {
                AlumnoService service = new AlumnoService();
                var dominio = new Alumno
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Correo = model.Correo,
                    FechaNacimiento = model.FechaNacimiento
                };
                service.Insert(dominio);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            AlumnoService service = new AlumnoService();
            var alumno = service.FindId(Id);
            AlumnoModel model = new AlumnoModel
            {
                Id = alumno.Id,
                Nombre = alumno.Nombre,
                Apellido = alumno.Apellido,
                Correo = alumno.Correo,
                FechaNacimiento = alumno.FechaNacimiento
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            AlumnoService service = new AlumnoService();
            var alumno = service.FindId(Id);
            AlumnoModel model = new AlumnoModel
            {
                Id = alumno.Id,
                Nombre = alumno.Nombre,
                Apellido = alumno.Apellido,
                Correo = alumno.Correo,
                FechaNacimiento = alumno.FechaNacimiento
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit (AlumnoModel alumno)
        {
            if (ModelState.IsValid)
            {
                AlumnoService service = new AlumnoService();
                var dominio = new Alumno
                {
                    Id = alumno.Id,
                    Nombre = alumno.Nombre,
                    Apellido = alumno.Apellido,
                    Correo = alumno.Correo,
                    FechaNacimiento = alumno.FechaNacimiento
                };
                service.Update(dominio);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            AlumnoService service = new AlumnoService();
            var alumno = service.FindId(Id);
            AlumnoModel model = new AlumnoModel
            {
                Id = alumno.Id,
                Nombre = alumno.Nombre,
                Apellido = alumno.Apellido,
                Correo = alumno.Correo,
                FechaNacimiento = alumno.FechaNacimiento
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(AlumnoModel alumno)
        {
            AlumnoService service = new AlumnoService();
            service.Delete(alumno.Id);
            return RedirectToAction("Index");
        }

    }
        
}
