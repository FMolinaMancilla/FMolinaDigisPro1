using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        // GET: AlumnoMateria
        public ActionResult GetAll()
        {

            ML.Alumno alumno = new ML.Alumno();
            ML.Result result = BL.Alumno.GetAll();

            if (result.Correct)
            {
                alumno.Alumnos = result.Objects;
            }
            return View(alumno);
        }

        [HttpGet]
        public ActionResult GetMateriaAsignada(int IdAlumno)
        {
            ML.Result result = BL.AlumnoMateria.GetMateriaAsignada(IdAlumno);
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();

            ML.Result resultalumno = BL.Alumno.GetById(IdAlumno);

            alumnomateria.AlumnoMaterias = result.Objects;
            alumnomateria.Alumno = (ML.Alumno)resultalumno.Object;

            return View(alumnomateria);
        }

        [HttpGet]
        public ActionResult GetMateriaSinAsignar(int IdAlumno)
        {
            ML.Result result = BL.AlumnoMateria.GetMateriaNoAsignada(IdAlumno);
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

            ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno);

            alumnoMateria.AlumnoMaterias = result.Objects;
            alumnoMateria.Alumno = (ML.Alumno)resultAlumno.Object;

            return View(alumnoMateria);
        }

        [HttpPost]
        public ActionResult GetMateriaSinAsignar(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            if(alumnoMateria.AlumnoMaterias != null)
            {
                foreach(string IdMateria in alumnoMateria.AlumnoMaterias)
                {
                    ML.AlumnoMateria alumnoMateriaItem = new ML.AlumnoMateria();

                    alumnoMateriaItem.Alumno = new ML.Alumno();
                    alumnoMateriaItem.Alumno.IdAlumno = alumnoMateria.Alumno.IdAlumno;

                    alumnoMateriaItem.Materia = new ML.Materia();
                    alumnoMateriaItem.Materia.IdMateria = int.Parse(IdMateria);

                    ML.Result resul = BL.AlumnoMateria.Add(alumnoMateriaItem);
                }

                result.Correct = true;
                ViewBag.Message = "Se ha actualizado al alumno";
                ViewBag.MateriasAsignadas = true;
                ViewBag.IdAlumno = alumnoMateria.Alumno.IdAlumno;
            }
            else
            {
                result.Correct = false;
            }

            return PartialView("ModalAlumnoMateria");
        }

        public ActionResult Delete(int IdAlumnoMateria, int IdAlumno)
        {
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
            alumnomateria.IdAlumnoMateria = IdAlumnoMateria;
            ML.Result result = BL.AlumnoMateria.Delete(alumnomateria);

            ViewBag.MateriasAsignadas = true;
            ViewBag.IdAlumno = IdAlumno;

            if (result.Correct)
            {
                ViewBag.message = "Se ha eliminado exitosamente el registro";
            }
            else
            {
                ViewBag.message = "ocurrió un error al eliminar el registro " + result.ErrorMessage;

            }
            return PartialView("ModalAlumnoMateria");
        }
    }
}
