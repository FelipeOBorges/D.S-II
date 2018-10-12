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
    public class Funcionario_DAL
    {
        public static string Cadastrar(Funcionario_DTO obj)
        {
            try
            {
                string script = "INSERT INTO TB_FUNCIONARIO (NOME, RG, TEL, CPF, ENDERECO, ID_FUNC, BANCO, CONTA, AGENCIA) values (@Nome, @Rg, @Tel, @Cpf, @Endereco, @IdFunc, @Banco, @Conta, @Agencia)"; 
                SqlCommand cm = new SqlCommand(script, Conexao.Login()); 
                cm.Parameters.AddWithValue("@Nome", obj.Nome); 
                cm.Parameters.AddWithValue("@Rg", obj.Rg);
                cm.Parameters.AddWithValue("@Tel", obj.Tel);
                cm.Parameters.AddWithValue("@Cpf", obj.Cpf);
                cm.Parameters.AddWithValue("@Endereco", obj.Endereco);
                cm.Parameters.AddWithValue("@IdFunc", obj.IdFun);
                cm.Parameters.AddWithValue("@Banco", obj.Banco);
                cm.Parameters.AddWithValue("@Conta", obj.Conta);
                cm.Parameters.AddWithValue("@Agencia", obj.Agencia);
                SqlDataReader dados = cm.ExecuteReader();
                return "sucesso";
            }
            catch
            {
                string fail = "Falha ao cadastrar no banco de dados!";
                return fail;
            }
            finally
            {
                if (Conexao.Login().State != ConnectionState.Closed) //Se o status da Conexão foi diferente de Aberto, ele fecha;
                {
                    Conexao.Login().Close(); //Ele fecha;
                }
            }
        }

        public static Funcionario_DTO RetornaBusc(string cpf)
        {
            try
            {
                Funcionario_DTO obj = new Funcionario_DTO();
                string script = "SELECT * FROM TB_FUNCIONARIO WHERE CPF = @CPF";
                SqlCommand cm = new SqlCommand(script, Conexao.Login());
                cm.Parameters.AddWithValue("@CPF", cpf);

                SqlDataReader dados = cm.ExecuteReader();

                while (dados.Read())
                {
                    if (dados.HasRows)
                    {
                        obj.Id = int.Parse(dados["ID"].ToString());
                        obj.Nome = dados["NOME"].ToString();
                        obj.Rg = dados["RG"].ToString();
                        obj.Tel = dados["TEL"].ToString();
                        obj.Cpf = dados["CPF"].ToString();
                        obj.Endereco = dados["ENDERECO"].ToString();
                        obj.IdFun = dados["ID_FUNC"].ToString();
                        obj.Banco = dados["BANCO"].ToString();
                        obj.Conta = dados["CONTA"].ToString();
                        obj.Agencia = dados["AGENCIA"].ToString();
                        return obj;
                    }
                    
                }
                throw new Exception("CPF não encontrado" + cpf);
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


        public static bool PesquisarCpf(string cpf)
        {
            try
            {
                string script = "SELECT * FROM TB_FUNCIONARIO WHERE CPF = @CPF";
                SqlCommand cm = new SqlCommand(script, Conexao.Login());
                cm.Parameters.AddWithValue("@CPF", cpf);

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

        public static string AlterarFuncionario(Funcionario_DTO obj)
        {
            try
            {
                string script = "UPDATE TB_FUNCIONARIO SET NOME = @nome, RG = @rg, TEL = @tel, CPF = @cpf, ENDERECO = @endereco, ID_FUNC = @id_func, BANCO = @banco, CONTA = @conta, AGENCIA = @agencia";
                SqlCommand cm = new SqlCommand(script, Conexao.Login());
                cm.Parameters.AddWithValue("@nome", obj.Nome);
                cm.Parameters.AddWithValue("@rg", obj.Rg);
                cm.Parameters.AddWithValue("@tel", obj.Tel);
                cm.Parameters.AddWithValue("@cpf", obj.Cpf);
                cm.Parameters.AddWithValue("@endereco", obj.Endereco);
                cm.Parameters.AddWithValue("@id_func", obj.IdFun);
                cm.Parameters.AddWithValue("@banco", obj.Banco);
                cm.Parameters.AddWithValue("@conta", obj.Conta);
                cm.Parameters.AddWithValue("@agencia", obj.Agencia);
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

    }
}
