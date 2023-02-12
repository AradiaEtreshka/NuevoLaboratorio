using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabClases;
using Clases;
using Laboratorio.entity;
using System.Net.Configuration;

namespace Model
{
    public class ProtocoloModel
    {
        public void newProtocol(Protocolo newProtocol)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandText = "insert into Protocolo (nombre, fechaInicio, fechaFin, puntaje, idEstadoProtocolo, idProyecto, idResponsableProtocolo) values (@nombre, @fechaInicio, @fechaFin, @puntaje, @idEstadoProtocolo, @idProyecto, @idResponsableProtocolo)";
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = newProtocol.Nombre;
            cmd.Parameters.Add("@fechaInicio", SqlDbType.DateTime).Value = newProtocol.FechaInicio;
            cmd.Parameters.Add("@fechaFin", SqlDbType.DateTime).Value = newProtocol.FechaFin;
            cmd.Parameters.Add("@puntaje", SqlDbType.Float).Value = newProtocol.Puntaje;
            cmd.Parameters.Add("@idEstadoProtocolo", SqlDbType.Int).Value = newProtocol.IdEstadoProtocolo;
            cmd.Parameters.Add("@idProyecto", SqlDbType.Int).Value = newProtocol.IdProyecto;
            cmd.Parameters.Add("@idResponsableProtocolo", SqlDbType.Int).Value = newProtocol.IdResponsableProtocolo;
            cmd.ExecuteNonQuery();

        }
        
        public  Protocolo getProtocol(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandText = "select * from Protocolo where id = @id";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet data = new DataSet();
            adapter.Fill(data);
            DataRow dataRow = data.Tables[0].Rows[0];
            Protocolo protocol = new Protocolo();
            protocol.Id = Convert.ToInt32(dataRow["Id"]);
            protocol.Nombre = (string)dataRow["Nombre"];
            protocol.FechaFin = ((DateTime)dataRow["FechaFin"]).ToString("MM/dd/yyyy");
            protocol.FechaInicio = ((DateTime)dataRow["FechaInicio"]).ToString("MM/dd/yyyy");
            protocol.Puntaje = Convert.ToDouble(dataRow["Puntaje"]);
            protocol.IdEstadoProtocolo = (EstadoProtocolo)Convert.ToInt32(dataRow["IdEstadoProtocolo"]);
            protocol.IdProyecto = Convert.ToInt32(dataRow["IdProyecto"]);
            protocol.IdResponsableProtocolo = Convert.ToInt32(dataRow["IdResponsableProtocolo"]);
            return protocol;

        }

        public static DataSet getProtocols()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandText = "select * from Protocolo";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet data = new DataSet();
            adapter.Fill(data);
            return data;
        }

        public static DataSet getProtocolsByIdProyect(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandText = "select * from Protocolo where IdProyecto="+id;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet data = new DataSet();
            adapter.Fill(data);
            return data;
        }

        public void updateProtocol(Protocolo protocol)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandText = "update Protocolo set nombre = @nombre, fechaInicio = @fechaInicio, fechaFin = @fechaFin, puntaje = @puntaje, idResponsableProtocolo = @idResponsableProtocolo where id = @id";
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = protocol.Nombre;
            cmd.Parameters.Add("@fechaInicio", SqlDbType.DateTime).Value = protocol.FechaInicio;
            cmd.Parameters.Add("@fechaFin", SqlDbType.DateTime).Value = protocol.FechaFin;
            cmd.Parameters.Add("@puntaje", SqlDbType.Float).Value = protocol.Puntaje;
            cmd.Parameters.Add("@idResponsableProtocolo", SqlDbType.Int).Value = protocol.IdResponsableProtocolo;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = protocol.Id;
            cmd.ExecuteNonQuery();
        }

        public void deleteProtocol(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandText = "delete from Protocolo where id="+id;
            cmd.ExecuteNonQuery();
        }

        public void promedioProtocolo(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandText = "obtenerpromedioprotocolo";
            cmd.Parameters.AddWithValue("Id_Protocolo", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }

        public void finalizarProtocolo(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "cambiarestadoprotocolofinalizado";
            cmd.Parameters.AddWithValue("idprotocolo", id);
            cmd.ExecuteNonQuery();
        }

        public void puntuarProtocolo(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandText = "update Protocolo set puntaje = (select AVG (Puntaje) FROM [dbo].[Actividad] where actividad.IdProtocolo = @protocolo ) where Id = @protocolo";
            cmd.Parameters.Add("@protocolo", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
            
        }

        
    }

    
}
