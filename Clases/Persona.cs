using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio.entity
{
    public class Persona
    {

        int id;
        string nombre;
        string apellido;
        int dni;

        public Persona(int id, string nombre, string apellido, int dni)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Dni { get => dni; set => dni = value; }
        
    }
}