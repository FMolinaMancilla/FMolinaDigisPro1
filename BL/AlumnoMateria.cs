using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {
        public static ML.Result GetMateriaAsignada(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaDigiPro1Entities1 context = new DL.FMolinaDigiPro1Entities1())
                {
                    var query = context.AlumnoGetMateriasAsignadas(IdAlumno).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.IdAlumnoMateria = obj.IdAlumnoMateria;

                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Materia.Nombre = obj.MateriaNombre;

                            alumnoMateria.Alumno = new ML.Alumno();
                            alumnoMateria.Alumno.IdAlumno = obj.IdAlumno;

                            result.Objects.Add(alumnoMateria);
                            result.Correct = true;

                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo realizar la consulta";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetMateriaNoAsignada(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaDigiPro1Entities1 context = new DL.FMolinaDigiPro1Entities1())
                {
                    var query = context.AlumnoMateriaNoAsignada(IdAlumno).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Materia.IdMateria = obj.IdMateria;
                            alumnoMateria.Materia.Nombre = obj.Nombre;
                            alumnoMateria.Materia.Costo = obj.Costo.Value;

                            result.Objects.Add(alumnoMateria);

                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo realizar la consulta";
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

        public static ML.Result Add(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaDigiPro1Entities1 context = new DL.FMolinaDigiPro1Entities1())
                {
                    var query = context.AlumnoMateriaAdd(alumnoMateria.Alumno.IdAlumno, alumnoMateria.Materia.IdMateria);
                    {
                        if (query >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se ha podido realizar el insert";
                        }
                        result.Correct = true;
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

        public static ML.Result Delete(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaDigiPro1Entities1 context = new DL.FMolinaDigiPro1Entities1())
                {
                    var query = context.AlumnoMateriaDelete(alumnoMateria.IdAlumnoMateria);

                    if(query >= 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un problema al eliminar";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
