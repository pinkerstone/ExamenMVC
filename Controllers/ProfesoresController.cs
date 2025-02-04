using Microsoft.AspNetCore.Mvc;
using ExamenMVC.Models;
using Services;
using Domain;

namespace ExamenMVC.Controllers
{
    public class ProfesoresController : Controller
    {
        public IActionResult Index()
        {

            ProfesorService service = new ProfesorService();

            var profesores = service.Get();

            var model = profesores.Select(x => new ProfesorModel
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Correo = x.Correo,
                Especialidad = x.Especialidad
            }).ToList();

            return View(model);
        }

        public IActionResult IndexAjax()
        {
            return View();
        }
        
        public IActionResult GetAjax()
        {

            ProfesorService service = new ProfesorService();

            var profesores = service.Get();

            var model = profesores.Select(x => new ProfesorModel
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Correo = x.Correo,
                Especialidad = x.Especialidad
            }).ToList();

            return Json(model);
        }

        public IActionResult GetFilter(string _filter)
        {

            ProfesorService service = new ProfesorService();

            var profesores = service.GetFilter(_filter);

            var model = profesores.Select(x => new ProfesorModel
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Correo = x.Correo,
                Especialidad = x.Especialidad
            }).ToList();

            return Json(model);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProfesorModel model)
        {
            if (ModelState.IsValid)
            {
                ProfesorService service = new ProfesorService();

                var dominio = new Profesor
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Correo = model.Correo,
                    Especialidad = model.Especialidad
                };
                service.Insert(dominio);
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            ProfesorService service = new ProfesorService();
            var profesor = service.FindId(Id);
            ProfesorModel model = new ProfesorModel
            {
                Id = profesor.Id,
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                Correo = profesor.Correo,
                Especialidad = profesor.Especialidad
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            ProfesorService service = new ProfesorService();
            var profesor = service.FindId(Id);
            ProfesorModel model = new ProfesorModel
            {
                Id = profesor.Id,
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                Correo = profesor.Correo,
                Especialidad = profesor.Especialidad
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProfesorModel profesor)
        {
            if (ModelState.IsValid)
            {
                ProfesorService service = new ProfesorService();
                var dominio = new Profesor
                {
                    Id = profesor.Id,
                    Nombre = profesor.Nombre,
                    Apellido = profesor.Apellido,
                    Correo = profesor.Correo,
                    Especialidad = profesor.Especialidad
                };
                service.Update(dominio);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            ProfesorService service = new ProfesorService();
            var profesor = service.FindId(Id);
            ProfesorModel model = new ProfesorModel
            {
                Id = profesor.Id,
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                Correo = profesor.Correo,
                Especialidad = profesor.Especialidad
            };

            return View(model);

        }

        [HttpPost]
        public ActionResult Delete(ProfesorModel profesor)
        {
            ProfesorService service = new ProfesorService();
            service.Delete(profesor.Id);
            return RedirectToAction("Index");
        }




    }
}
