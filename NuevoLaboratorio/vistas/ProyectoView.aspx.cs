using LabClases;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Clases;


namespace NuevoLaboratorio.vistas
{
    public partial class ProyectoView : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GV_Proyecto.DataSource = ProyectoModel.getProyects();
                GV_Proyecto.DataBind();
                cargarResponsables();
            }
        }

        protected void nuevo_Proyecto_Click(object sender, EventArgs e)
        {
            PNL_NuevoProyecto.Visible = true;
            BTN_Guardar.Text = "Guardar";
        }

        protected void BTN_Guardar_Click(object sender, EventArgs e)
        {
            if (HF_Modificar.Value == "")
            {
                try
                {
                    Proyecto newProyect = new Proyecto();
                    newProyect.Nombre = TB_NombreProyecto.Text;
                    newProyect.FechaInicio = (DateTime.Today.ToString());
                    newProyect.FechaFin = TB_FechaFin.Text;
                    newProyect.Observaciones = TB_Observaciones.Text;
                    newProyect.Responsable = Convert.ToInt32(DDL_Responsable.SelectedValue);
                    ProyectoModel proyectoModel = new ProyectoModel();
                    proyectoModel.newProyect(newProyect);

                    GV_Proyecto.DataSource = ProyectoModel.getProyects();
                    GV_Proyecto.DataBind();

                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert", "Swal.fire({position: 'top-end',icon: 'success',  title: 'El proyecto se ha guardado correctamente',  showConfirmButton: false,  timer: 1500})", true);

                    PNL_NuevoProyecto.Visible = false;
                    TB_NombreProyecto.Text = "";
                    TB_FechaFin.Text = "";
                    TB_Observaciones.Text = "";

                }
                catch 
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert", "Swal.fire({position: 'top-end',icon: 'error',  title: 'Error al guardar el proyecto',  showConfirmButton: false,  timer: 1500})", true);

                }

            }
            else
            {
                try
                {

                    Proyecto modProyect = new Proyecto();
                    modProyect.Nombre = TB_NombreProyecto.Text;
                    modProyect.FechaFin = TB_FechaFin.Text;
                    modProyect.Observaciones = TB_Observaciones.Text;
                    modProyect.Responsable = int.Parse(DDL_Responsable.SelectedItem.Value);
                    ProyectoModel proyectoModel = new ProyectoModel();
                    proyectoModel.updateProyect(modProyect);
                    GV_Proyecto.DataSource = ProyectoModel.getProyects();
                    GV_Proyecto.DataBind();


                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert1", "Swal.fire({ icon: 'success',  title: 'Proyecto modificado',  text: 'El proyecto se modifico correctamente'})", true);

                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert1", "Swal.fire({ icon: 'error',  title: 'Oops...',  text: 'Error '})", true);
                }

            }
        }
    

        

        protected void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            PNL_NuevoProyecto.Visible = false;
        }

        protected void GV_Proyecto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Modificar")
            {
                try
                {
                    PNL_NuevoProyecto.Visible = true;
                    nuevo_Proyecto.Visible = false;
                    int id = Convert.ToInt32(e.CommandArgument);
                    HF_Modificar.Value = id.ToString();
                    ProyectoModel proyectoModel = new ProyectoModel();
                    Proyecto proyectmod = proyectoModel.getProyect(id);
                    TB_NombreProyecto.Text = proyectmod.Nombre;
                    FechaFinMostrar.Text = "Fecha de finalizacion actual: " + proyectmod.FechaFin;
                    TB_Observaciones.Text = proyectmod.Observaciones;
                    DDL_Responsable.SelectedValue = proyectmod.Responsable.ToString();
                    
                    
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert1", "Swal.fire({ icon: 'error',  title: 'Oops...',  text: 'Error al cargar el proyecto'})", true);
                }
            }
            
            else if (e.CommandName == "Eliminar")
            {
                
                try
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    ProyectoModel proyectoModel = new ProyectoModel();
                    proyectoModel.deleteProyect(id);
                    Response.Write("<script>alert('Proyecto eliminado con exito')</script>");
                    GV_Proyecto.DataSource = ProyectoModel.getProyects();
                    GV_Proyecto.DataBind();

                    //int id = Convert.ToInt32(e.CommandArgument);
                    //ProyectoModel proyectoModel = new ProyectoModel();
                    //Proyecto proyectoDelete = proyectoModel.getProyect(id);
                    //proyectoModel.deleteProyect(id);
                    //Response.Write("<script>alert('Proyecto eliminado con exito')</script>");
                    //GV_Proyecto.DataSource = ProyectoModel.getProyects();
                    //GV_Proyecto.DataBind();
                    //int contador = 0;
                    //int cantProtocolos = 0; ;
                    //int puntaje = 0;

                    //foreach (Laboratorio.entity.Protocolo p in proyectoDelete.Protocolos)
                    //{
                    //    cantProtocolos = cantProtocolos + 1;
                    //    puntaje = puntaje + (int)p.Puntaje;

                    //    if (p.Puntaje >= 7)
                    //    {
                    //        contador = contador + 1;

                    //    }

                    //}

                    //if (cantProtocolos == 0)
                    //{
                    //proyectoModel.deleteProyect(id);
                    //Response.Write("<script>alert('Proyecto eliminado con exito')</script>");
                    //GV_Proyecto.DataSource = ProyectoModel.getProyects();
                    //GV_Proyecto.DataBind();
                    //}

                    //else

                    //{
                    //    Response.Write("<script>alert('No se permite eliminar proyectos con protocolos asignados.')</script>");
                    //}


                }

                catch
                {
                    Response.Write("<script>alert('No se puede eliminar este Proyecto por poseer protocolos')</script>");

                }
            }

            else if (e.CommandName == "Iniciar")
            {
                try
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    ProyectoModel proyectoModel = new ProyectoModel();
                    proyectoModel.iniciarProyecto(id);

                    ScriptManager.RegisterStartupScript(this, GetType(), "alert1", "<script>alert('Proyecto iniciado con exito')</script>", true);
                    GV_Proyecto.DataSource = ProyectoModel.getProyects();
                    GV_Proyecto.DataBind();
                }

                catch
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert1", "<script>alert('Error al iniciar proyecto')</script>", true);
                }
            }

            else if (e.CommandName == "Rechazar")
            {
                try
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    ProyectoModel proyectoModel = new ProyectoModel();
                    proyectoModel.rechazarProyecto(id);

                    ScriptManager.RegisterStartupScript(this, GetType(), "alert1", "<script>alert('El Proyecto fue rechazado')</script>", true);
                    GV_Proyecto.DataSource = ProyectoModel.getProyects();
                    GV_Proyecto.DataBind();
                }

                catch
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert1", "<script>alert('Error al rechazar proyecto')</script>", true);
                }
            }

            else if (e.CommandName == "Finalizar")
            {
                try
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    ProyectoModel proyectoModel = new ProyectoModel();
                    proyectoModel.finalizarProyecto(id);
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert1", "<script>alert('El Proyecto fue finalizado')</script>", true);
                    GV_Proyecto.DataSource = ProyectoModel.getProyects();
                    GV_Proyecto.DataBind();
                    
                    
                    
                }

                catch
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert1", "<script>alert('Error al finalizar proyecto')</script>", true);
                }

            }

        }

        public void cargarResponsables()

        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "listarResponsables";
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            ////DDL_Responsable.DataSource = ds;
            DDL_Responsable.DataSource = cmd.ExecuteReader();
            DDL_Responsable.DataTextField = "Nombre";
            DDL_Responsable.DataValueField = "Id";
            DDL_Responsable.DataBind();
            //return ds;
        }

        public bool enableButton(string id)

        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            ProyectoModel proyectoModel = new ProyectoModel();
            Proyecto proyect = proyectoModel.getProyect(Convert.ToInt32(id));
            EstadoProyecto estado = proyect.EstadoProyecto;
            
            if (estado == EstadoProyecto.Rechazado || estado == EstadoProyecto.Aprobado || estado == EstadoProyecto.Desaprobado)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }


}