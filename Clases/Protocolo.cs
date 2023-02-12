using LabClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio.entity
{
    public class Protocolo
    {
        int id;
        string nombre;
        string fechaInicio;
        string fechaFin;
        double puntaje;
        EstadoProtocolo idEstadoProtocolo;
        int idProyecto;
        int idResponsableProtocolo;

        public Protocolo()
        {
            
        }

        public Protocolo(int id, string nombre, string fechaInicio, string fechaFin, double puntaje, int idEstadoProtocolo, int idProyecto, int idResponsableProtocolo)
                
        {
            this.Id = id;
            this.Nombre = nombre;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
            this.Puntaje = puntaje;
            this.IdEstadoProtocolo = EstadoProtocolo.Iniciado;
            this.IdProyecto = idProyecto;
            this.IdResponsableProtocolo = idResponsableProtocolo;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public string FechaFin { get => fechaFin; set => fechaFin = value; }
        public double Puntaje { get => puntaje; set => puntaje = value; }
        public EstadoProtocolo IdEstadoProtocolo { get => idEstadoProtocolo; set => idEstadoProtocolo = value; }
        public int IdProyecto { get => idProyecto; set => idProyecto = value; }
        public int IdResponsableProtocolo { get => idResponsableProtocolo; set => idResponsableProtocolo = value; }
    }
}