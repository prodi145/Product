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
    public partial class tipocpu : System.Web.UI.Page
    {
        CapaNegocioTipoCPU objTipCPU = null;
        CapaNegocioModeloCPU objModelCPU = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //para tipo cpu
                objTipCPU = new CapaNegocioTipoCPU(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objTipCPU"] = objTipCPU;
                //para modelo de cpu
                objModelCPU = new CapaNegocioModeloCPU(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objModelCPU"] = objModelCPU;
            }
            else
            {
                //para tipo cpu
                objTipCPU = (CapaNegocioTipoCPU)Session["objTipCPU"];
                //´para modelo de cpu
                objModelCPU = (CapaNegocioModeloCPU)Session["objModelCPU"];
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            List<EntidadModeloCPU> listaAtrapada = null;
            string m = "";
            int b = 0;
            listaAtrapada = objModelCPU.DevuelveIdModeloCPU(ref m);
            
            DropDownList1.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList1.Items.Add(
                    new ListItem(
                        listaAtrapada[a].id_modcpu + " " 
                        ));
            }
            TextBox3.Text = m;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadTipoCPU nuevo = new EntidadTipoCPU()
            {
                Tipo = TextBox1.Text,
                Familia = TextBox2.Text,
                Velocidad = TextBox4.Text,
                Extra = TextBox5.Text,
                id_modCPU= Convert.ToInt16(DropDownList1.SelectedValue)
            };
            string cad = "";
            objTipCPU.InsertarTipoCPU(nuevo, ref cad);
            TextBox3.Text = cad;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objTipCPU.ObtenTodoTipoCPU(ref m);
            GridView1.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView1.DataBind();
        }
    }
}