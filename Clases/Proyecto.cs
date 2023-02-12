using LabClases;
using Laboratorio.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Proyecto
    {
        int id;
        string nombre;
        string fechaInicio;
        string fechaFin;
        string observaciones;
        int idResponsable;
        EstadoProyecto estado;
        List<Protocolo> protocolos = new List<Protocolo>();
        bool protocolospendientes;


        public Proyecto()
        {

        }

        public int Id { get => id; set => id = value;}
        public string Nombre { get => nombre; set => nombre = value; }
        public string FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public string FechaFin { get => fechaFin; set => fechaFin = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public int Responsable { get => idResponsable; set => idResponsable = value; }
        public EstadoProyecto EstadoProyecto { get => estado; set => estado = value; }
        public List<Protocolo> Protocolos { get => protocolos; set => protocolos = value; }
        public bool ProtocolosPendientes { get => protocolospendientes; set => protocolospendientes = value; }

        public Proyecto(string nombre, string fechaInicio, string fechaFin, string observaciones, int responsable)
        {

            Nombre = nombre;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Observaciones = observaciones;
            Responsable = responsable;
        }
    }
}
