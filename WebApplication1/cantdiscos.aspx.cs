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
	public partial class cantdiscos : System.Web.UI.Page
	{
        CapaNegocioComputFinal objComFin = null;
        CapaNegocioDiscoDuro objDis = null;
        CapaNegocioCantDisc objCant = null;
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                //para tipo cpu
                objComFin = new CapaNegocioComputFinal(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objComFin"] = objComFin;
                //para modelo disco duro
                objDis = new CapaNegocioDiscoDuro(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objDis"] = objDis;
                //para modelo cantidad dis
                objCant = new CapaNegocioCantDisc(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objCant"] = objCant;
            }
            else
            {
                //para tipo cpu
                objComFin = (CapaNegocioComputFinal)Session["objComFin"];
                //´para disco duro
                objDis = (CapaNegocioDiscoDuro)Session["objDis"];
                //´para cantidad dis
                objCant = (CapaNegocioCantDisc)Session["objCant"];
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
            List<EntidadDiscoDuro> listaAtrapada = null;
            string m = "";
            listaAtrapada = objDis.DevuelveIdDiscoDuro(ref m);
            DropDownList2.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList2.Items.Add(
                    new ListItem(
                        listaAtrapada[a].id_Disco + " "
                        ));
            }
            TextBox3.Text = m;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadCantDisc nuevo = new EntidadCantDisc()
            {
                num_inv = Convert.ToString(DropDownList1.SelectedValue),
                id_Disco = Convert.ToInt16(DropDownList2.SelectedValue),
            };
            string cad = "";
            objCant.InsertarCantDisc(nuevo, ref cad);
            TextBox3.Text = cad;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objCant.ObtenTodCantidadDisc(ref m);
            GridView1.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView1.DataBind();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            List<EntidadCantDisc> listaAtrapada = null;
            string m = "";
            listaAtrapada = objCant.DevuelveInfoCantDisco(ref m);
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            EntidadCantDisc nuevo = new EntidadCantDisc()
            {
                num_inv = DropDownList3.SelectedValue,
            };
            string cad = "";
            objCant.EliminarCantDisc(nuevo, ref cad);
            TextBox3.Text = cad;
        }
    }
}