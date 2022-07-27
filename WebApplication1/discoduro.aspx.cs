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
    public partial class discoduro : System.Web.UI.Page
    {
        CapaNegocioDiscoDuro objDiscoD = null;
        CapaNegocioMarca objMarc = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //para tipo disco
                objDiscoD = new CapaNegocioDiscoDuro(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objDiscoD"] = objDiscoD;
                //para modelo de marrca
                objMarc = new CapaNegocioMarca(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objMarc"] = objMarc;


            }
            else
            {
                //para tipo disco
                objDiscoD = (CapaNegocioDiscoDuro)Session["objDiscoD"];
                //´para marca
                objMarc = (CapaNegocioMarca)Session["objMarc"];
                
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            List<EntidadMarca> listaAtrapada = null;
            string m = "";
            listaAtrapada = objMarc.DevuelveIDMarca(ref m);
            DropDownList1.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList1.Items.Add(
                    new ListItem(
                        listaAtrapada[a].Id_Marca + " " 
                        ));
            }
            TextBox5.Text = m;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadDiscoDuro nuevo = new EntidadDiscoDuro()
            {
                TipoDisco = TextBox1.Text,
                conector = TextBox2.Text,
                Capacidad = TextBox3.Text,
                F_MarcaDisco = Convert.ToInt16(DropDownList1.SelectedValue),
                Extra = TextBox4.Text
            };
            string cad = "";
            objDiscoD.InsertarDiscoDuro(nuevo, ref cad);
            TextBox5.Text = cad;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objDiscoD.ObtenTodDiscoDuro(ref m);
            GridView1.DataSource = Session["Tabla1"];
            TextBox5.Text = m;
            GridView1.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            List<EntidadDiscoDuro> listaAtrapada = null;
            string m = "";
            listaAtrapada = objDiscoD.DevuelveInfoDiscoDuro(ref m);
            DropDownList2.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList2.Items.Add(
                    new ListItem(
                        listaAtrapada[a].TipoDisco + " "
                        ));
            }
            TextBox5.Text = m;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            EntidadDiscoDuro nuevo = new EntidadDiscoDuro()
            {
                TipoDisco = DropDownList2.SelectedValue,
            };
            string cad = "";
            objDiscoD.EliminarDiscoDuro(nuevo, ref cad);
            TextBox5.Text = cad;
        }
    }
}