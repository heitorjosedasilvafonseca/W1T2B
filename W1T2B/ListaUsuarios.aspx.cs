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
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            string nivel = Session["Perfil"].ToString();
            if (nivel == "O")
            {
                btnAdicionar.Visible = false;
            }
            CarregarUsuarios();
        }
        #endregion

        #region CarregarUsuarios
        private void CarregarUsuarios()
        {
            string query = @"select id, nome, nivel from usuario";
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, Conexao.Connection);
                da.Fill(dt);

                //Popular Repeater
                rptUsuarios.DataSource = dt;
                rptUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Falhou!! " + ex.Message;
            }

        }
        #endregion

        #region btnAdicionar_Click
        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("NovoUsuario.aspx");
        }
        #endregion

        #region rptUsuarios_ItemDataBound
        protected void rptUsuarios_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            string nivel = Session["Perfil"].ToString();
            var lnkRemover = (LinkButton)e.Item.FindControl("lnkRemover");

            if (lnkRemover != null && nivel == "O")
            {
                lnkRemover.Visible = false;
            }
        }
        #endregion

    }
}