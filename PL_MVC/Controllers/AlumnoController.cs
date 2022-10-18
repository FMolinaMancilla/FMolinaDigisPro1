using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        [HttpGet]
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
        public ActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();

            if (IdAlumno == null)
            {
                return View(alumno);
            }
            else
            {
                //UPDATE

                ML.Result result = BL.Alumno.GetById(IdAlumno.Value);
                alumno = (ML.Alumno)result.Object;

                return View(alumno);

            }
        }

        [HttpPost]

        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            if(alumno.IdAlumno == 0)
            {
                result = BL.Alumno.Add(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "Registro Exitoso";
                }
                else
                {
                    ViewBag.Message = "Error al registrar" + result.ErrorMessage;
                }
            }
            else
            {
                //UPDATE
                result = BL.Alumno.Update(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "Registro Actualizado";
                }
                else
                {
                    ViewBag.Message = "Error al actualizar" + result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(ML.Alumno alumno)
        {


            ML.Result result = BL.Alumno.Delete(alumno);

            if (result.Correct)
            {
                ViewBag.Message = "¡Registro eliminado!";
            }
            else
            {
                ViewBag.Message = "¡No se elimino el registro!" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }

    }
}