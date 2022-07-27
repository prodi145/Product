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
    public partial class marcompo : System.Web.UI.Page
    {
        CapaNegocioMarca objMarc = null;
        CapaNegocioComponentes objCompo = null;
        CapaNegocioMarCom objMarCo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //para componente
                objCompo = new CapaNegocioComponentes(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objCompo"] = objCompo;
                //para modelo de marrca
                objMarc = new CapaNegocioMarca(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objMarc"] = objMarc;
                //para modelo de componente
                objMarCo = new CapaNegocioMarCom(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objMarCo"] = objMarCo;

            }
            else
            {
                //para componente
                objCompo = (CapaNegocioComponentes)Session["objCompo"];
                //´para marca
                objMarc = (CapaNegocioMarca)Session["objMarc"];
                //´para componente
                objMarCo = (CapaNegocioMarCom)Session["objMarCo"];
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            List<EntidadComponentes> listaAtrapada = null;
            string m = "";
            listaAtrapada = objCompo.DevuelveIdComponentes(ref m);
            DropDownList1.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList1.Items.Add(
                    new ListItem(
                        listaAtrapada[a].id_Componente + " "
                        ));
            }
            TextBox5.Text = m;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            List<EntidadMarca> listaAtrapada = null;
            string m = "";
            listaAtrapada = objMarc.DevuelveIDMarca(ref m);
            DropDownList2.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList2.Items.Add(
                    new ListItem(
                        listaAtrapada[a].Id_Marca + " "
                        ));
            }
            TextBox5.Text = m;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadMarCom nuevo = new EntidadMarCom()
            {
                Idcomponente = Convert.ToInt16(DropDownList1.SelectedValue),
                Idmarca = Convert.ToInt16(DropDownList2.SelectedValue)
            };
            string cad = "";
            objMarCo.InsertarMarcaComponente(nuevo, ref cad);
            TextBox5.Text = cad;
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objMarCo.ObtenTodasMarcaComponente(ref m);
            GridView1.DataSource = Session["Tabla1"];
            TextBox5.Text = m;
            GridView1.DataBind();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            List<EntidadMarCom> listaAtrapada = null;
            string m = "";
            listaAtrapada = objMarCo.DevuelveInfoMarcaComponente(ref m);
            DropDownList3.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList3.Items.Add(
                    new ListItem(
                        listaAtrapada[a].Idcomponente + " "
                        ));
            }
            TextBox5.Text = m;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            EntidadMarCom nuevo = new EntidadMarCom()
            {
                Idcomponente = Convert.ToInt16(DropDownList3.SelectedValue),
            };
            string cad = "";
            objMarCo.EliminarMarcaComponente(nuevo, ref cad);
            TextBox5.Text = cad;
        }
    }
}