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
    public class Produto_DAL
    {
        public static string CadastrarProduto(Produto__DTO obj)
        {
            try
            {
                string script = "INSERT INTO TB_PRODUTOS (CODIGO, PRODUTO, PRECO, ESTOQUE, TIPO, UNID_MEDIA) values (@Codigo, @Produto, @Preco, @Estoque, @Tipo, @Uni_med)";
                SqlCommand cm = new SqlCommand(script, Conexao.Login());
                cm.Parameters.AddWithValue("@Codigo", obj.Codigo );
                cm.Parameters.AddWithValue("@Produto", obj.Produto);
                cm.Parameters.AddWithValue("@Preco", obj.Preco);
                cm.Parameters.AddWithValue("@Estoque", obj.Estoque);
                cm.Parameters.AddWithValue("@Tipo", obj.Tipo);
                cm.Parameters.AddWithValue("@Uni_med", obj.Uni_media);
                SqlDataReader daods = cm.ExecuteReader();
                return "sucesso";
            }
            catch
            {
                string fail = "Falaa ao cadastrar no Banco de dados!";
                return fail;
            }
            finally
            {

                if (Conexao.Login().State != ConnectionState.Closed) 
                {
                    Conexao.Login().Close(); 
                }
            }
        }

        public static Produto__DTO RetornaBuscaProduto(string produto)
        {
            try
            {
                Produto__DTO obj = new Produto__DTO();
                string script = "SELECT * FROM TB_PRODUTOS WHERE PRODUTO = @Produto";
                SqlCommand cm = new SqlCommand(script, Conexao.Login());
                cm.Parameters.AddWithValue("@Produto", produto);
                SqlDataReader dados = cm.ExecuteReader();

                while (dados.Read())
                {
                    if (dados.HasRows)
                    {
                        obj.Codigo = (dados["CODIGO"].ToString());
                        obj.Produto = (dados["PRODUTO"].ToString());
                        obj.Preco = (dados["PRECO"].ToString());
                        obj.Estoque = (dados["ESTOQUE"].ToString());
                        obj.Tipo = (dados["TIPO"].ToString());
                        obj.Uni_media = (dados["UNID_MEDIA"].ToString());
                        return obj;
                    }
                }
                throw new Exception("Produto não encontrado no Banco de dados " + produto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conexao.Login().State != ConnectionState.Closed)
                {
                    Conexao.Login().Close();
                }
            }
        }
        public static string AlterarProduto(Produto__DTO obj)
        {
            try
            {
                string script = "UPDATE TB_PRODUTOS SET CODIGO = @codigo, PRODUTO = @produto, PRECO = @Preco, ESTOQUE = @estoque, TIPO = @tipo, UNID_MEDIA = @unid_media";
                SqlCommand cm = new SqlCommand(script, Conexao.Login());
                cm.Parameters.AddWithValue("@codigo", obj.Codigo);
                cm.Parameters.AddWithValue("@produto", obj.Produto);
                cm.Parameters.AddWithValue("@preco", obj.Preco);
                cm.Parameters.AddWithValue("@estoque", obj.Estoque);
                cm.Parameters.AddWithValue("@tipo", obj.Tipo);
                cm.Parameters.AddWithValue("@unid_media", obj.Uni_media);
                cm.ExecuteNonQuery();
                return "Alterado com sucesso!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conexao.Login().State != ConnectionState.Closed)
                {
                    Conexao.Login().Close();
                }
            }
        }

        public static bool PesquisarProduto(string produto)
        {
            try
            {
                string script = "SELECT * FROM TB_PRODUTOS WHERE PRODUTO = @produto";
                SqlCommand cm = new SqlCommand(script, Conexao.Login());
                cm.Parameters.AddWithValue("@produto", produto);

                SqlDataReader dados = cm.ExecuteReader();

                while (dados.Read())
                {
                    if (dados.HasRows)
                    {
                        return true;
                    }
                }
                return false;

            }
            catch
            {
                throw new Exception("Problemas na conexão!");
            }
        
        }
    }
}
