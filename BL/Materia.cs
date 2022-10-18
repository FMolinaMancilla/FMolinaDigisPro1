using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaDigiPro1Entities1 context = new DL.FMolinaDigiPro1Entities1())
                {
                    var query = context.MateriaAdd(materia.Nombre, materia.Costo);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false; 
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaDigiPro1Entities1 context = new DL.FMolinaDigiPro1Entities1())
                {
                    var query = context.MateriaUpdate(materia.IdMateria,materia.Nombre, materia.Costo);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaDigiPro1Entities1 context = new DL.FMolinaDigiPro1Entities1())
                {
                    var query = context.MateriaGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Materia materia = new ML.Materia();
                           
                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.Costo = obj.Costo.Value;
                           
                            result.Objects.Add(materia);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }

        public static ML.Result GetById(int IdMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.FMolinaDigiPro1Entities1 context = new DL.FMolinaDigiPro1Entities1())
                {
                    var query = context.MateriaGetById(IdMateria).FirstOrDefault();


                    if (query != null)
                    {
                        ML.Materia materia = new ML.Materia();

                        materia.IdMateria = query.IdMateria;
                        materia.Nombre = query.Nombre;
                        materia.Costo = query.Costo.Value;

                        result.Object = materia;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;

                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result DeleteEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.FMolinaDigiPro1Entities1 context = new DL.FMolinaDigiPro1Entities1())
                {
                    var query = context.MateriaDelete(materia.IdMateria);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
