using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio.entity
{
    public class Actividad
    {

        int id;
        string descripcion;
        double puntaje;
        bool finalizada;
        int idProtocolo;

   
        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Puntaje { get => puntaje; set => puntaje = value; }
        public bool Finalizada { get => finalizada; set => finalizada = value; }
        public int IdProtocolo { get => idProtocolo; set => idProtocolo = value; }
    }
}