using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        [HttpGet]
        public ActionResult GetAll()
        {

            ML.Materia materia = new ML.Materia();
            ML.Result result = BL.Materia.GetAll();

            if (result.Correct)
            {
                materia.Materias = result.Objects;
            }
            return View(materia);
        }
    }
}