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
	public partial class laboratorio : System.Web.UI.Page
	{
        CapaNegocioLaboratorio objBAct = null;

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {

                
                objBAct = new CapaNegocioLaboratorio(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objAct"] = objBAct;

            }
            else
            {

                
                objBAct = (CapaNegocioLaboratorio)Session["objAct"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadLaboratorio nuevo = new EntidadLaboratorio()
            {
                nombre_laboratorio = TextBox1.Text

            };
            string cad = "";
            objBAct.InsertarLaboratorio(nuevo, ref cad);
            TextBox2.Text = cad;
            TextBox1.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objBAct.ObtenTodLaboratorio(ref m);
            GridView1.DataSource = Session["Tabla1"];
            TextBox2.Text = m;
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            EntidadLaboratorio nuevo = new EntidadLaboratorio()
            {
                nombre_laboratorio = DropDownList2.SelectedValue
            };
            string cad = "";
            objBAct.EliminarLaboratorio(nuevo, ref cad);
            TextBox2.Text = cad;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            List<EntidadLaboratorio> listaAtrapada = null;
            string m = "";
            listaAtrapada = objBAct.DevuelveInfoLaboratorio(ref m);
            DropDownList2.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList2.Items.Add(
                    new ListItem(
                        listaAtrapada[a].nombre_laboratorio + " "
                        ));
            }
            TextBox2.Text = m;
        }
    }
}