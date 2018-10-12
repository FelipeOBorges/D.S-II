using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Restaurante;
using System.Data;
using System.Data.SqlClient;

namespace DAL_Restaurante
{
    public class Login_DAL
    {
        public static string ValidarLogin(Login_DTO obj)
        {
            try
            {
                string script = "SELECT * FROM TB_LOGIN WHERE USUARIO = @usuario AND SENHA = @senha"; //STRING RECEBENDO O RESULTADO DA CONSULTA NO BANCO DE DADOS;
                SqlCommand cm = new SqlCommand(script, Conexao.Login()); //RODA O SCRIPT EM UMA DETERMINADA SESSÃO;
                cm.Parameters.AddWithValue("@usuario", obj.Usuario); //Passa como parametro para o Obj.Usuario o valor da busca no select @usuario;
                cm.Parameters.AddWithValue("@senha", obj.Senha); //Passa como parametro para o Obj.Senha o valor da busca no select @senha;

                SqlDataReader dados = cm.ExecuteReader();
                while (dados.Read()) //Roda o script até achar algo;
                {
                    if (dados.HasRows)//Se achar alguma linha com a busca no banco de dados com usuario e senha correto sucesso
                    {
                        return "sucesso";
                       
                    }
                }
                return "Usuário ou Senha inválida!";//Se não achar nenhuma linha retorna erro;
            }
            catch //(Exception ex)
            {
                throw new Exception("Problema na conexão!");
                //return (ex.Message);
            }

        }
    }
}
