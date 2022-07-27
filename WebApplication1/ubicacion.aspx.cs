using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Data.SqlClient;
using System.Data;
using ClassBLInventario;
using ClassCapaEntidad;
using System.Configuration;

namespace WebApplication1
{
	public partial class ubicacion : System.Web.UI.Page
	{
        CapaNegocioComputFinal objComFin = null;
        CapaNegocioLaboratorio objLab = null;
        CapaNegocioUbicacion objUb = null;
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                //para tipo cpu
                objComFin = new CapaNegocioComputFinal(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objComFin"] = objComFin;
                //para modelo de cpu
                objLab = new CapaNegocioLaboratorio(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objLab"] = objLab;
                //ubicacion
                objUb = new CapaNegocioUbicacion(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objUb"] = objUb;
            }
            else
            {
                //para tipo cpu
                objComFin = (CapaNegocioComputFinal)Session["objComFin"];
                //´para modelo de cpu
                objLab = (CapaNegocioLaboratorio)Session["objLab"];
                //ubicacion
                objUb = (CapaNegocioUbicacion)Session["objUb"];
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            List<EntidadComputadoraFinal> listaAtrapada = null;
            string m = "";
            listaAtrapada = objComFin.DevuelveInfoComputadorFinal(ref m);
            DropDownList1.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList1.Items.Add(
                    new ListItem(
                        listaAtrapada[a].num_inv + " "
                        ));
            }
            TextBox3.Text = m;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            List<EntidadLaboratorio> listaAtrapada = null;
            string m = "";
            listaAtrapada = objLab.DevuelveInfoLaboratorio(ref m);
            DropDownList2.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList2.Items.Add(
                    new ListItem(
                        listaAtrapada[a].nombre_laboratorio + " "
                        ));
            }
            TextBox3.Text = m;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadUbicacion nuevo = new EntidadUbicacion()
            {
                num_inv = Convert.ToString(DropDownList1.SelectedValue),
                nombre_laboratorio = Convert.ToString(DropDownList2.SelectedValue),
            };
            string cad = "";
            objUb.InsertarUbicacion(nuevo, ref cad);
            TextBox3.Text = cad;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objUb.ObtenTodaUbicacion(ref m);
            GridView1.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            EntidadUbicacion nuevo = new EntidadUbicacion()
            {
                num_inv = DropDownList3.SelectedValue,
            };
            string cad = "";
            objUb.EliminarUbicacion(nuevo, ref cad);
            TextBox3.Text = cad;
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            List<EntidadUbicacion> listaAtrapada = null;
            string m = "";
            listaAtrapada = objUb.DevuelveInfUbicacion(ref m);
            DropDownList3.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList3.Items.Add(
                    new ListItem(
                        listaAtrapada[a].num_inv + " "
                        ));
            }
            TextBox3.Text = m;
        }
    }
}