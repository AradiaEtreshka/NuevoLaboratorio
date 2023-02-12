using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabClases;
using Clases;
using Laboratorio.entity;
using System.Data;

namespace Model
{
    public class ActividadModel
    {

        public void newActivity(Actividad newActivity)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandText = "INSERT INTO Actividad (descripcion, puntaje, finalizada, idProtocolo) VALUES (@descripcion, @puntaje, @finalizada, @idProtocolo)";
            cmd.Parameters.AddWithValue("@descripcion", newActivity.Descripcion);
            cmd.Parameters.AddWithValue("@puntaje", newActivity.Puntaje);
            cmd.Parameters.AddWithValue("@finalizada", newActivity.Finalizada);
            cmd.Parameters.AddWithValue("@idProtocolo", newActivity.IdProtocolo);
            cmd.ExecuteNonQuery();
        }
        
        public static DataSet getActivitiesByIdProtocol(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandText = "select * from Actividad where IdProtocolo=" + id;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;           
        }

        public Actividad getActivity(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandText = "SELECT * FROM Actividad WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow row = ds.Tables[0].Rows[0];
            Actividad actividad = new Actividad();
            actividad.Id = Convert.ToInt32(row["id"]);
            actividad.Descripcion = row["descripcion"].ToString();
            actividad.Puntaje = Convert.ToDouble(row["puntaje"]);
            actividad.Finalizada = Convert.ToBoolean(row["finalizada"]);
            actividad.IdProtocolo = Convert.ToInt32(row["idProtocolo"]);
            
            return actividad;
        }

        public void updateActivity(Actividad actividad)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandText = "UPDATE Actividad SET descripcion = @descripcion, puntaje = @puntaje, finalizada = @finalizada, idProtocolo = @idProtocolo WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", actividad.Id);
            cmd.Parameters.AddWithValue("@descripcion", actividad.Descripcion);
            cmd.Parameters.AddWithValue("@puntaje", actividad.Puntaje);
            cmd.Parameters.AddWithValue("@finalizada", actividad.Finalizada);
            cmd.Parameters.AddWithValue("@idProtocolo", actividad.IdProtocolo);
            cmd.ExecuteNonQuery();
        }

        public void deleteActivity(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandText = "DELETE FROM Actividad WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }

        
    
}
