using LabClases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Clases;
using Laboratorio.entity;

namespace NuevoLaboratorio.vistas
{
    public partial class ProtocoloView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (this.Request.QueryString["Id"] != null)
                {
                    int idProyecto = Convert.ToInt32(this.Request.QueryString["Id"]);
                    GV_Protocolo.DataSource = ProtocoloModel.getProtocolsByIdProyect(idProyecto);
                    GV_Protocolo.DataBind();
                    cargarResponsables();
                }

            }
            else
            {

           
            int idProyecto = Convert.ToInt32(this.Request.QueryString["Id"]);
            GV_Protocolo.DataSource = ProtocoloModel.getProtocolsByIdProyect(idProyecto);
            GV_Protocolo.DataBind(); }
        }

        protected void nuevo_Protocolo_Click(object sender, EventArgs e)
        {
            PNL_NuevoProtocolo.Visible = true;
        }

        protected void BTN_Guardar_Click(object sender, EventArgs e)
        {

            if(HF_ModificarProtocolo.Value == "")
            {
                try
                {
                    Protocolo newProtocol = new Protocolo();
                    newProtocol.IdProyecto = Convert.ToInt32(this.Request.QueryString["Id"]);
                    newProtocol.Nombre = TB_NombreProtocolo.Text;
                    newProtocol.FechaFin = TB_FechaFin.Text;
                    newProtocol.FechaInicio = TB_FechaInicio.Text;
                    newProtocol.IdResponsableProtocolo = int.Parse(DDL_Responsable.SelectedValue);
                    newProtocol.IdEstadoProtocolo = EstadoProtocolo.Iniciado;
                    ProtocoloModel protocoloModel = new ProtocoloModel();
                    protocoloModel.newProtocol(newProtocol);

                    PNL_NuevoProtocolo.Visible = false;

                    int idProyecto = Convert.ToInt32(this.Request.QueryString["Id"]);
                    GV_Protocolo.DataSource = ProtocoloModel.getProtocolsByIdProyect(idProyecto);
                    GV_Protocolo.DataBind();

                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert", "Swal.fire({position: 'top-end',icon: 'success',  title: 'El protocolo se ha guardado correctamente',  showConfirmButton: false,  timer: 1500})", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert", "Swal.fire({position: 'top-end',icon: 'error',  title: 'El protocolo no se ha guardado correctamente',  showConfirmButton: false,  timer: 1500})", true);
                }
 
            }

            else
            {
                try
                {
                    Protocolo modProtocol = new Protocolo();
                    modProtocol.Id = int.Parse(HF_ModificarProtocolo.Value);
                    modProtocol.Nombre = TB_NombreProtocolo.Text;
                    modProtocol.FechaInicio = TB_FechaInicio.Text;
                    modProtocol.FechaFin = TB_FechaFin.Text;
                    modProtocol.IdResponsableProtocolo = Convert.ToInt32(DDL_Responsable.SelectedItem.Value);
                    ProtocoloModel protocoloModel = new ProtocoloModel();
                    protocoloModel.updateProtocol(modProtocol);

                    
                    int idProyecto = Convert.ToInt32(this.Request.QueryString["Id"]);
                    GV_Protocolo.DataSource = ProtocoloModel.getProtocolsByIdProyect(idProyecto);
                    GV_Protocolo.DataBind();

                    PNL_NuevoProtocolo.Visible = false;

                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert", "Swal.fire({position: 'top-end',icon: 'success',  title: 'El protocolo se ha modificado correctamente',  showConfirmButton: false,  timer: 1500})", true);

                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert", "Swal.fire({position: 'top-end',icon: 'error',  title: 'El protocolo no se ha modificado correctamente',  showConfirmButton: false,  timer: 1500})", true);

                }
            }

        }

        protected void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            PNL_NuevoProtocolo.Visible = false;
        }

        protected void GV_Protocolo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Modificar") 
            {
                try
                {
                    int idProtocolo = Convert.ToInt32(e.CommandArgument);
                    HF_ModificarProtocolo.Value = idProtocolo.ToString();
                    ProtocoloModel protocoloModel = new ProtocoloModel();
                    Protocolo protocoloMod = protocoloModel.getProtocol(idProtocolo);
                    TB_NombreProtocolo.Text = protocoloMod.Nombre;
                    FechaInicioProtocolo.Text = "La fecha de Inicio del protocolo es: " + protocoloMod.FechaInicio;
                    FechaFinProtocolo.Text = "La fecha de finalización para este protocolo es: " + protocoloMod.FechaFin;
                    DDL_Responsable.SelectedValue = protocoloMod.IdResponsableProtocolo.ToString();

                    PNL_NuevoProtocolo.Visible = true;


                }
                catch 
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert1", "<script>alert('Error al modificar Proyecto')</script>", true);
                }
            }

            else if (e.CommandName == "Eliminar")
            {
                try
                {
                    int idProtocolo = Convert.ToInt32(e.CommandArgument);
                    ProtocoloModel protocoloModel = new ProtocoloModel();
                    protocoloModel.deleteProtocol(idProtocolo);
                    Response.Write("<script>alert('Protocolo eliminado con exito')</script>");
                    int idProyecto = Convert.ToInt32(this.Request.QueryString["Id"]);
                    GV_Protocolo.DataSource = ProtocoloModel.getProtocolsByIdProyect(idProyecto);
                    GV_Protocolo.DataBind();


                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert1", "<script>alert('Error al eliminar protocolo')</script>", true);

                }
            }

            else if (e.CommandName == "PuntuarProtocol")
            {
                try
                {
                    int idProtocolo = Convert.ToInt32(e.CommandArgument);
                    HF_ModificarProtocolo.Value = idProtocolo.ToString();
                    ProtocoloModel protocoloModel = new ProtocoloModel();
                    Protocolo protocoloMod = protocoloModel.getProtocol(idProtocolo);
                    protocoloModel.puntuarProtocolo(idProtocolo);

                    int idProyecto = Convert.ToInt32(this.Request.QueryString["Id"]);
                    GV_Protocolo.DataSource = 
                    ProtocoloModel.getProtocolsByIdProyect(idProyecto);
                    GV_Protocolo.DataBind();

                    Response.Write("<script>alert('Protocolo puntuado con exito')</script>");
                }
                catch
                {
                    
                }
            }
                
                  
        }


        public DataSet cargarResponsables()

        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conectarBD();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "listarresponsableProtocolo";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DDL_Responsable.DataSource = ds;
            DDL_Responsable.DataSource = cmd.ExecuteReader();
            DDL_Responsable.DataTextField = "Nombre";
            DDL_Responsable.DataValueField = "Id";
            DDL_Responsable.DataBind();
            return ds;
        }

        protected void volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/vistas/ProyectoView");

        }
    }
}