using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using LabClases;

namespace Laboratorio
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            string email = typeEmailX.Text;
            string password = typePasswordX.Text;
            var pos = email.LastIndexOf("@");

            if (pos > 0 && (email.LastIndexOf(".") > pos) && (email.Length - pos > 4))
            {
                if (password.Length > 5)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Datos.conectarBD();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "login";
                    cmd.Parameters.AddWithValue("email", typeEmailX.Text);
                    cmd.Parameters.AddWithValue("password", typePasswordX.Text);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);


                    if (dataTable.Rows.Count > 0)
                    {
                        Response.Redirect("/vistas/ProyectoView");

                    }

                    else
                    {
                        Response.Write("<script language=javascript>alert('Ingrese contraseña valida');</script>");
                    }
                }

                else
                {
                    Response.Write("<script language=javascript>alert('ingrese un email valido');</script>");
                }


            }


        }
    }

}