using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string Get()
        {
            string conexion = ConfigurationManager.ConnectionStrings["FMolinaDigisPro1"].ConnectionString;

            return conexion;
        }
    }
}
