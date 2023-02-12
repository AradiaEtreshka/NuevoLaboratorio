using Laboratorio.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Clases;
using Laboratorio.entity;

namespace NuevoLaboratorio.vistas
{
    public partial class ActividadView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HF_IdProtocol.Value = this.Request.QueryString["Id"];

            if (!IsPostBack)
            {

                if (this.Request.QueryString["Id"] != null)
                {                    
                    GV_Actividades.DataSource = ActividadModel.getActivitiesByIdProtocol(Convert.ToInt32(HF_IdProtocol.Value));
                    GV_Actividades.DataBind();
                }

            }
        }

        protected void nueva_Actividad_Click(object sender, EventArgs e)
        {
            PNL_NuevaActividad.Visible = true;
        }

        protected void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            PNL_NuevaActividad.Visible = false;
        }

        protected void BTN_Guardar_Click(object sender, EventArgs e)
        {
            if (HF_ModificarActividad.Value == "")
            {
                try
                {
                    Actividad newActividad = new Actividad();
                    newActividad.IdProtocolo = Convert.ToInt32(HF_IdProtocol.Value);
                    newActividad.Descripcion = TB_Descripcion.Text;
                    newActividad.Finalizada = false;
                    newActividad.Puntaje = 0;
                    ActividadModel actividadModel = new ActividadModel();
                    actividadModel.newActivity(newActividad);

                    PNL_NuevaActividad.Visible = false;
                    TB_Descripcion.Text = "";
                 
                    GV_Actividades.DataSource = ActividadModel.getActivitiesByIdProtocol(Convert.ToInt32(HF_IdProtocol.Value));
                    GV_Actividades.DataBind();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Actividad Guardada", "openModal();", true);

                }

                catch
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error al guardar la Actividad", "openModal();", true);
                }
            }

            else
            {
                try
                {
                    Actividad actividad = new Actividad();
                    actividad.Id = Convert.ToInt32(HF_ModificarActividad.Value);
                    actividad.Descripcion = TB_Descripcion.Text;
                    actividad.Finalizada = actividad.Puntaje > 0 ? true : false;
                    actividad.Puntaje = Convert.ToInt32(TB_Puntaje.Text);
                    actividad.IdProtocolo = Convert.ToInt32(HF_IdProtocol.Value);

                    ActividadModel actividadModel = new ActividadModel();
                    actividadModel.updateActivity(actividad);

                    PNL_NuevaActividad.Visible = false;
                    TB_Descripcion.Text = "";
                    TB_Puntaje.Text = "";

                    GV_Actividades.DataSource = ActividadModel.getActivitiesByIdProtocol(Convert.ToInt32(HF_IdProtocol.Value));
                    GV_Actividades.DataBind();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Actividad Modificada", "openModal();", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error al modificar la Actividad", "openModal();", true);
                }
            }           
        }

        protected void GV_Actividades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idActividad = Convert.ToInt32(e.CommandArgument);
                ActividadModel actividadModel = new ActividadModel();
                actividadModel.deleteActivity(idActividad);
                GV_Actividades.DataSource = ActividadModel.getActivitiesByIdProtocol(Convert.ToInt32(HF_IdProtocol.Value));
                GV_Actividades.DataBind();
            }

            if(e.CommandName == "Puntuar")
            {
                PNL_NuevaActividad.Visible = true;
                TB_Puntaje.Visible = true;
                int id = Convert.ToInt32(e.CommandArgument);
                HF_ModificarActividad.Value = id.ToString();
                ActividadModel actividadModel = new ActividadModel();
                Actividad actividadpun = actividadModel.getActivity(id);
                TB_Descripcion.Text = actividadpun.Descripcion;
                TB_Puntaje.Text = actividadpun.Puntaje.ToString();
                actividadModel.updateActivity(actividadpun);

                GV_Actividades.DataSource = ActividadModel.getActivitiesByIdProtocol(Convert.ToInt32(HF_IdProtocol.Value));
                GV_Actividades.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Actividad Modificada", "openModal();", true);

            }
        }

        protected void volver_Click(object sender, EventArgs e)
        {
            int IdProtocolo = Convert.ToInt32(HF_IdProtocol.Value);
            Response.Redirect("/vistas/ProyectoView");
        }
    }
}