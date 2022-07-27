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
    public partial class componentes : System.Web.UI.Page
    {
        CapaNegocioComponentes objCompo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //para componentes
                objCompo = new CapaNegocioComponentes(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objCompo"] = objCompo;
            }
            else
            {
                //para componentes
                objCompo = (CapaNegocioComponentes)Session["objCompo"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadComponentes nuevo = new EntidadComponentes()
            {
                categoria = TextBox1.Text
            };
            string cad = "";
            objCompo.InsertarComponentes(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox1.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objCompo.ObtenTodComponentes(ref m);
            GridView1.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView1.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            List<EntidadComponentes> listaAtrapada = null;
            string m = "";
            listaAtrapada = objCompo.DevuelveInfoComponentes(ref m);
            DropDownList1.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList1.Items.Add(
                    new ListItem(
                        listaAtrapada[a].categoria + " "
                        ));
            }
            TextBox3.Text = m;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            EntidadComponentes nuevo = new EntidadComponentes()
            {
                categoria = DropDownList1.SelectedValue,
            };
            string cad = "";
            objCompo.EliminarComponentes(nuevo, ref cad);
            TextBox3.Text = cad;
        }
    }
}