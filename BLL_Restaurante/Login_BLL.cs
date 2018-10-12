using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Restaurante;
using DTO_Restaurante;

namespace BLL_Restaurante
{
    public class Login_BLL
    {
        public static string ValidarLogin(Login_DTO obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Usuario))
            {
                return "Campo usuário vazio!";
                //throw new Exception("Campo usuário vazio!");
            }
            if (string.IsNullOrWhiteSpace(obj.Senha))
            {
                return "Campo senha vazio!";
                //throw new Exception("Campo senha vazio!");
            }
            return Login_DAL.ValidarLogin(obj);
        }
    }
}
