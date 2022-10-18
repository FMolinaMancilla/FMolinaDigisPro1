using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;


namespace SL_WebAPI.Controllers
{
    public class MateriaController : ApiController
    {
        // GET: Materia
        [HttpGet]
        [Route("api/Materia/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            ML.Result result = BL.Materia.GetAll();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        //// GET: Materia/Details/5
        //public IHttpActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Materia/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Materia/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Materia/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Materia/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Materia/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Materia/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}