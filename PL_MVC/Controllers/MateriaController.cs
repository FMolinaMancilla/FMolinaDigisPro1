using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

            //ML.Materia materia = new ML.Materia();
            //ML.Result result = BL.Materia.GetAll();

            //if (result.Correct)
            //{
            //    materia.Materias = result.Objects;
            //}
            //return View(materia);

            ML.Materia resultMateria = new ML.Materia();
            resultMateria.Materias = new List<object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10710/");
                var responseTask = client.GetAsync("api/Materia/GetAll");

                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                        resultMateria.Materias.Add(resultItemList);
                    }
                }
            }
            return View(resultMateria);
        }

        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();
    
            {
                if (IdMateria == null)//Add
                {
                    return View(materia);
                }
                else
                {
                    ML.Result result = new ML.Result();
                    using (var client = new HttpClient())
                        try
                        {
                            client.BaseAddress = new Uri("http://localhost:10710/");
                            var responseTask = client.GetAsync("api/Materia/GetById/{IdMateria}" + IdMateria);

                            responseTask.Wait();

                            var resultAPI = responseTask.Result;
                            if (resultAPI.IsSuccessStatusCode)
                            {
                                var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                                readTask.Wait();

                                ML.Materia resultItemList = new ML.Materia();
                                resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());

                                result.Object = resultItemList;

                                materia = (ML.Materia)result.Object;
                                materia.Materias.Add(resultItemList);
                                return View(materia);
                            }
                            else
                             {
                                result.Correct = false;
                                result.ErrorMessage = "No existen registros";
                            }

                        }
                        catch (Exception ex)
                        {
                            result.Correct = false;
                            result.ErrorMessage = ex.Message;
                        }
                    return View();
                }
            }
            //ML.Materia materia = new ML.Materia();

            //if (IdMateria == null)
            //{
            //    return View(materia);
            //}
            //else
            //{
            //    //UPDATE

            //    ML.Result result = BL.Materia.GetById(IdMateria.Value);
            //    materia = (ML.Materia)result.Object;

            //    return View(materia);

            //}
        }

        [HttpPost]

        public ActionResult Form(ML.Materia materia)
        {
            ML.Result result = new ML.Result();


            if (materia.IdMateria == 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:10710/");
                    var postTask = client.PostAsJsonAsync<ML.Materia>("api/Materia/Add", materia);
                    postTask.Wait();

                    var resultMateria = postTask.Result;
                    if (resultMateria.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Registro realizado correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "Error al registrar" + result.ErrorMessage;
                    }

                }

            }
            else
            {
                //UPDATE
                //result = BL.Materia.Update(materia);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:10710/");

                    var postTask = client.PostAsJsonAsync<ML.Materia>("api/Materia/Update/{IdMateria}" + materia.IdMateria, materia);
                    postTask.Wait();

                    var resultMateria = postTask.Result;
                    if (resultMateria.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Registro Actualizado";
                    }
                    else
                    {
                        ViewBag.Message = "Error al actualizar" + result.ErrorMessage;

                    }
                }
            }
            return PartialView("Modal");
        }


        [HttpGet]
        public ActionResult Delete(int IdMateria)
        {
            ML.Result resultMateria = new ML.Result();
            ML.Materia materia = new ML.Materia();

            materia.IdMateria = IdMateria;

            using (var client = new HttpClient())
            {
                //HttpPost
                client.BaseAddress = new Uri("http://localhost:10710/");
                var postTask = client.DeleteAsync("api/Materia/Delete/{IdMateria}" + IdMateria);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    ViewBag.Message = "La materia ha sido eliminada";
                }
                else
                {
                    ViewBag.Message = "La materia no pudo ser eliminada" + resultMateria.ErrorMessage;
                }
            }

            return PartialView("Modal");

            //ML.Result result = BL.Materia.Delete(materia);

            //if (result.Correct)
            //{
            //    ViewBag.Message = "¡Registro eliminado!";
            //}
            //else
            //{
            //    ViewBag.Message = "¡No se elimino el registro!" + result.ErrorMessage;
            //}
            //return PartialView("Modal");
        }

    }
}