using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W1T2B
{
    public partial class editamigos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (CapturaID())
                {
                    DadosEditar();
                }
            }
        }

        private bool CapturaID()
        {
            return Request.QueryString.AllKeys.Contains("id");
        }

        private void DadosEditar()
        {
            var id = ObterID();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"select * from amigo
                                    where id =@id";

                cmd.Parameters.AddWithValue("@id", id);
                Conexao.Conectar();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    txtID.Text = reader["id"].ToString();
                    txtNome.Text = reader["nome"].ToString();
                    txtCelular.Text = reader["celular"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                    txtCidade.Text = reader["cidade"].ToString();
                }
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }

        }

        private int ObterID()
        {
            var id = 0;
            var idURL = Request.QueryString["id"];

            if (!int.TryParse(idURL, out id))
            {
                throw new Exception("ID inválido");
            }
            if (id <= 0)
            {
                throw new Exception("ID inválido");
            }
            return id;
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaAmigos.aspx");
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"update amigo 
                                    set nome = @nome,
                                    celular = @celular,
                                    email = @email,
                                    cidade = @cidade
                                    where id = @id;";

                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@celular", txtCelular.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@cidade", txtCidade.Text);

                Conexao.Conectar();
                cmd.ExecuteNonQuery();
                Response.Redirect("ListaAmigos.aspx");
            }
            catch (Exception ex)
            {
                lblResultado.Text = "Falha " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }
            Response.Redirect("ListaAmigos.aspx");
        }

    }
}