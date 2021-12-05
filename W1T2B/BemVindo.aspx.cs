using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W1T2B
{
    public partial class BemVindo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"select count(*) from usuario";
                Conexao.Conectar();
                int recs = int.Parse(cmd.ExecuteScalar().ToString());
                if (recs == 0) SalvaRoot();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conexao.Desconectar();
            }

        }

        public void SalvaRoot()
        {
            //Encriptar a senha
            var senhaEncriptada = BCrypt.Net.BCrypt.HashPassword(txtSenha.Text);

            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"insert into usuario
                                    (nome, login, senha, nivel)
                                    values
                                    (@nome, @login, @senha, @nivel)";

                cmd.Parameters.AddWithValue("nome", "root");
                cmd.Parameters.AddWithValue("login", "root");
                cmd.Parameters.AddWithValue("senha", "root");
                cmd.Parameters.AddWithValue("nivel", "A");

                Conexao.Conectar();
                cmd.ExecuteNonQuery();
                Response.Redirect("ListaUsuarios.aspx");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conexao.Desconectar();
            }


        }

        #region btnLogin_Click
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                string usuario = txtUsuario.Text;
                string senha = txtSenha.Text;

                cmd.Connection = Conexao.Connection;

                //Recuperar senha encriptada
                cmd.CommandText = @"select senha 
                                    from usuario
                                    where login=@login";
                cmd.Parameters.AddWithValue("login", usuario);
                Conexao.Conectar();

                string senhaEncriptada = Convert.ToString(cmd.ExecuteScalar());

                if (string.IsNullOrEmpty(senhaEncriptada))
                {
                    throw new Exception("Usuário ou Senha Inválida");
                }

                //Comparar a senhaEncriptada com a senha digitada
//                if (BCrypt.Net.BCrypt.Verify(senha, senhaEncriptada))
                if (senha == senhaEncriptada)
                    {
                        cmd.CommandText = @"select nivel
                                        from usuario
                                        where login = @usuario";
                    cmd.Parameters.AddWithValue("usuario", usuario);

                    string nivel = Convert.ToString(cmd.ExecuteScalar());

                    //Gravar Session
                    Session["Perfil"] = nivel;

                    //Fazer o Redirecionamento
                    FormsAuthentication.RedirectFromLoginPage(nivel, false);
                }
                else
                {
                    throw new Exception("Usuário ou Senha Inválida");
                }

            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
        #endregion
    }
}