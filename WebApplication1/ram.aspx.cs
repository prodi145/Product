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
	public partial class ram : System.Web.UI.Page
	{
        CapaNegocioRAM objRAM = null;
        CapaNegocioTipoRAM objTipRAM = null;


        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                // RAM
                objRAM = new CapaNegocioRAM(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objRAM"] = objRAM;
                //TIPO DE  RAM
                objTipRAM = new CapaNegocioTipoRAM(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objTipRAM"] = objTipRAM;
            }
            else
            {
                //RAM
                objRAM = (CapaNegocioRAM)Session["objRAM"];
                //TIPO DE RAM
                objTipRAM = (CapaNegocioTipoRAM)Session["objTipRAM"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadRAM nuevo = new EntidadRAM()
            {
                Capacidad = Convert.ToInt16(TextBox1.Text),
                Velocidad = TextBox2.Text,
                F_TipoR = Convert.ToInt16(DropDownList1.SelectedValue)
            };
            string cad = "";
            objRAM.InsertarRAM(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            List<EntidadTipoRAM> listaAtrapada = null;
            string m = "";
            
            listaAtrapada = objTipRAM.DevuelveIdTipRAM(ref m);

            DropDownList1.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList1.Items.Add(
                    new ListItem(
                        listaAtrapada[a].id_tipoRam + " "
                        ));
            }
            TextBox3.Text = m;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objRAM.ObtenTodaRAM(ref m);
            GridView1.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            List<EntidadRAM> listaAtrapada = null;
            string m = "";
            listaAtrapada = objRAM.DevuelveInfoRAM(ref m);
            DropDownList2.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList2.Items.Add(
                    new ListItem(
                        listaAtrapada[a].Capacidad + " "
                        ));
            }
            TextBox3.Text = m;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            EntidadRAM nuevo = new EntidadRAM()
            {
                Capacidad = Convert.ToInt16(DropDownList2.SelectedValue)
            };
            string cad = "";
            objRAM.EliminarRAM(nuevo, ref cad);
            TextBox3.Text = cad;
        }
    }
}