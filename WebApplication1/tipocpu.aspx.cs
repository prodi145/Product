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
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objTipCPU.ObtenTodoTipoCPU(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView2.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //protected void Button6_Click(object sender, EventArgs e)
        //{
        //    List<EntidadTipoCPU> listaAtrapada = null;
        //    string m = "";
        //    listaAtrapada = objTipCPU.DevuelveInfoTipoCPU(ref m);
        //    DropDownList2.Items.Clear();
        //    for (int a = 0; a < listaAtrapada.Count; a++)
        //    {
        //        DropDownList2.Items.Add(
        //            new ListItem(
        //                listaAtrapada[a].Tipo + " "
        //                ));
        //    }
        //    TextBox3.Text = m;
        //}

        protected void Button4_Click(object sender, EventArgs e)
        {
            EntidadTipoCPU nuevo = new EntidadTipoCPU()
            {
                id_Tcup = Convert.ToInt16(TextBox10.Text)
            };
            string cad = "";
            objTipCPU.EliminarTipoCPU(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox10.Text = "";
        }

        //protected void Button7_Click(object sender, EventArgs e)
        //{
        //    List<EntidadTipoCPU> listaAtrapada = null;
        //    string m = "";
        //    listaAtrapada =objTipCPU.DevuelveIdTipoCPU(ref m);
        //    DropDownList3.Items.Clear();
        //    for (int a = 0; a < listaAtrapada.Count; a++)
        //    {
        //        DropDownList3.Items.Add(
        //            new ListItem(
        //                listaAtrapada[a].id_Tcup + " "


        //                ));
        //    }
        //    TextBox3.Text = m;
        //}

        protected void Button3_Click(object sender, EventArgs e)
        {
            EntidadTipoCPU nuevo = new EntidadTipoCPU()
            {
                id_Tcup = Convert.ToInt16(TextBox11.Text),
                Tipo = TextBox6.Text,
                Familia = TextBox7.Text,
                Velocidad = TextBox8.Text,
                Extra = TextBox9.Text,
                id_modCPU = Convert.ToInt16(DropDownList4.SelectedValue)
            };
            string cad = "";
            objTipCPU.ModificarTipoCPU(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox11.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            List<EntidadModeloCPU> listaAtrapada = null;
            string m = "";
            int b = 0;
            listaAtrapada = objModelCPU.DevuelveIdModeloCPU(ref m);

            DropDownList4.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList4.Items.Add(
                    new ListItem(
                        listaAtrapada[a].id_modcpu + " "
                        ));
            }
            TextBox3.Text = m;
        }

        //metodo para traer datos y poder eliminar
        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            TextBox10.Text = GridView2.Rows[rowind].Cells[2].Text;
        }

        //metodo para traer datos y poder modificar
        protected void chkk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind2 = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            TextBox11.Text = GridView2.Rows[rowind2].Cells[2].Text;
            TextBox6.Text = GridView2.Rows[rowind2].Cells[3].Text;
            TextBox7.Text = GridView2.Rows[rowind2].Cells[4].Text;
            TextBox8.Text = GridView2.Rows[rowind2].Cells[5].Text;
            TextBox9.Text = GridView2.Rows[rowind2].Cells[6].Text;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}