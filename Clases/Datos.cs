using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabClases
{
    public class Datos
    {
        public static String conectar()
        {
            return "Data Source=DESKTOP-HE9F6M2\\MSSQLSERVER01;Initial Catalog=Laboratorio;User ID=sa;Password=sql;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
           
        }

        public static SqlConnection conectarBD()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = conectar();
            connection.Open();
            return connection;
        }


    }
}
