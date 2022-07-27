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
    public partial class gabinete : System.Web.UI.Page
    {
        CapaNegocioMarca objMarc = null;
        CapaNegocioGabinete objGabi = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //para gabinete
                objGabi = new CapaNegocioGabinete(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objGabi"] = objGabi;
                //para modelo de marrca
                objMarc = new CapaNegocioMarca(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objMarc"] = objMarc;


            }
            else
            {
                //para tipo gabinete
                objGabi = (CapaNegocioGabinete)Session["objGabi"];
                //´para marca
                objMarc = (CapaNegocioMarca)Session["objMarc"];

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadGabinete nuevo = new EntidadGabinete()
            {
                Modelo = TextBox1.Text,
                TipoForma = TextBox2.Text,
                F_Marca = Convert.ToInt16(DropDownList1.SelectedValue)
            };
            string cad = "";
            objGabi.InsertarGabinete(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox1.Text = "";
            TextBox2.Text = "";
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
            TextBox3.Text = m;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objGabi.ObtenTodasGabinete(ref m);
            GridView1.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView1.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            List<EntidadGabinete> listaAtrapada = null;
            string m = "";
            listaAtrapada = objGabi.DevuelveInfoGabinete(ref m);
            DropDownList2.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList2.Items.Add(
                    new ListItem(
                        listaAtrapada[a].Modelo + " "
                        ));
            }
            TextBox3.Text = m;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            EntidadGabinete nuevo = new EntidadGabinete()
            {
                Modelo = DropDownList2.SelectedValue,
            };
            string cad = "";
            objGabi.EliminarGabinete(nuevo, ref cad);
            TextBox3.Text = cad;
        }
    }
}