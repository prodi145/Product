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
	public partial class tiporam : System.Web.UI.Page
	{
        CapaNegocioTipoRAM objTipRAM = null;
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {


                objTipRAM = new CapaNegocioTipoRAM(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objTipRAM"] = objTipRAM;

            }
            else
            {


                objTipRAM = (CapaNegocioTipoRAM)Session["objTipRAM"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadTipoRAM nuevo = new EntidadTipoRAM()
            {
                Tipo = TextBox1.Text,
                Extra = TextBox2.Text

            };
            string cad = "";
            objTipRAM.InsertarTipoRAM(nuevo, ref cad);
            TextBox3.Text = cad;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objTipRAM.ObtenTodoTipoRAM(ref m);
            GridView1.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView1.DataBind();
        }
    }
}