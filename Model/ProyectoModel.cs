using System;
using System.Data.SqlClient;
using System.Data;
using LabClases;
using Clases;

namespace Model
{
    public class ProyectoModel
    {
        public void newProyect(Proyecto newProyect)
        {
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = Datos.conectarBD();
            //cmd.CommandText = "insert into Proyecto (nombre, fechaFin,IdEstadoProyecto, observaciones, fechaInicio,  responsable ) values (@nombre, @fechaFin, @IdEstadoProyecto, @observaciones, @fechaInicio, @responsable)";
            //cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = newProyect.Nombre;
            //cmd.Parameters.Add("@fechaFin", SqlDbType.DateTime).Value = newProyect.FechaFin;
            //cmd.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = newProyect.Observaciones;
            //cmd.Parameters.Add("@fechaInicio", SqlDbType.DateTime).Value = newProyect.FechaInicio;
            //cmd.Parameters.Add("@responsable", SqlDbType.Int).Value = newProyect.Responsable;
            //cmd.Parameters.Add("@IdEstadoProyecto",  1);
            //cmd.ExecuteNonQuery();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "altaProyecto";
            cmd.Parameters.AddWithValue("@nombre", newProyect.Nombre);
            cmd.Parameters.AddWithValue("@observaciones", newProyect.Observaciones);
            cmd.Parameters.AddWithValue("@fechaInit", newProyect.FechaInicio);
            cmd.Parameters.AddWithValue("@fechaEnd", SqlDbType.DateTime).Value = DateTime.Parse(newProyect.FechaFin);
            cmd.Parameters.AddWithValue("@responsable", newProyect.Responsable);
            cmd.ExecuteNonQuery();
        }

        public Proyecto getProyect(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proyectoPorId";
            cmd.Parameters.AddWithValue("Id", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet data = new DataSet();
            adapter.Fill(data);
            DataRow dataRow = data.Tables[0].Rows[0];
            Proyecto proyect = new Proyecto();
            proyect.Id = Convert.ToInt32(dataRow["Id"]);
            proyect.Nombre = (string)dataRow["Nombre"];
            proyect.FechaFin = ((DateTime)dataRow["FechaFin"]).ToString("MM/dd/yyyy");
            proyect.Observaciones = dataRow[5].ToString();
            proyect.Responsable = Convert.ToInt32(dataRow["Responsable"]);
            //proyect.EstadoProyecto = (EstadoProyecto)(dataRow["IdEstadoProyecto"]);
            return proyect;

        }
        
        public static DataSet getProyects()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "listarProyectos";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void deleteProyect(int id)
        {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Datos.conectarBD();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "eliminarProyecto";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();           

        }

        public void rechazarProyecto(int idProyect)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "rechazarProyecto";
            cmd.Parameters.AddWithValue("@idProyecto", idProyect);
            cmd.ExecuteNonQuery();

        }

        public void iniciarProyecto(int idProyect)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "iniciarProyecto";
            cmd.Parameters.AddWithValue("@idProyecto", idProyect);
            cmd.ExecuteNonQuery();

        }

        public void updateProyect(Proyecto proyectMod)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "modificarProyecto";
            cmd.Parameters.AddWithValue("@id", proyectMod.Id);
            cmd.Parameters.AddWithValue("@nombre", proyectMod.Nombre);
            cmd.Parameters.AddWithValue("@fechaEnd", proyectMod.FechaFin);
            cmd.Parameters.AddWithValue("@observaciones", proyectMod.Observaciones);
            cmd.Parameters.AddWithValue("@responsable", proyectMod.Responsable);
            cmd.ExecuteNonQuery();
        }

        public void finalizarProyecto(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "finalizarProyecto";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

        }

        //public bool protocolosPendientes(int id)
        //{

        //    return false;
        //}
      
    }
}
