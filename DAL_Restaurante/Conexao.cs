using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL_Restaurante
{
    public class Conexao
    {
        public static SqlConnection Login()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(localdb)\Projects;Initial Catalog=DB_RESTAURANTE;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
                con.Open();
                return con;
            }
            catch
            {
                throw new Exception("Não foi possível conectar ao Banco de Dados!!");
            }
        }
    }
}
