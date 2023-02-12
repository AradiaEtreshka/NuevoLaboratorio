using LabClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio.entity
{
    public class UserApp
    {
        int id;
        string userName;
        string password;
        Rol idRol;
        int idPersona;

        public UserApp(int id, string userName, string password, Rol idRol, int idPersona)
        {
            Id = id;
            UserName = userName;
            Password = password;
            IdRol = idRol;
            IdPersona = idPersona;

        }

        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public Rol IdRol { get => idRol; set => idRol = value; }
        public int IdPersona { get => idPersona; set => idPersona = value; }

        
    }
}