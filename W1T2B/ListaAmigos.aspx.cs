using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W1T2B
{
    public partial class ListaAmigos1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarAmigos();
        }

        private void CarregarAmigos()
        {
            string query = @"select * from amigo";
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, Conexao.Connection);
                da.Fill(dt);

                //Popular Repeater
                rptAmigos.DataSource = dt;
                rptAmigos.DataBind();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Falhou!! " + ex.Message;
            }

        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("NovoAmigo.aspx");
        }

        protected void rptAmigos_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
        }
    }
}