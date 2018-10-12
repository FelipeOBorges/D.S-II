using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Restaurante;
using DTO_Restaurante;

namespace BLL_Restaurante
{
    public class Funcionario_BLL
    {
        public static string ValidarFunc(Funcionario_DTO obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Nome))
            {
                return "Campo nome vazio!";
                //throw new Exception("Campo usuário vazio!");
            }
            if (string.IsNullOrWhiteSpace(obj.Rg))
            {
                return "Campo RG vazio!";
                //throw new Exception("Campo senha vazio!");
            }
            if (string.IsNullOrWhiteSpace(obj.Tel))
            {
                return "Campo Telefone vazio!";
                //throw new Exception("Campo senha vazio!");
            }
            bool teste_cpf = Funcionario_DAL.PesquisarCpf(obj.Cpf);
            if (teste_cpf == true)
            {
                return "CPF já existe na base de dados!";
            }
            if (string.IsNullOrWhiteSpace(obj.Endereco))
            {
                return "Campo Endereço vazio!";
                //throw new Exception("Campo senha vazio!");
            }
            if (string.IsNullOrWhiteSpace(obj.IdFun))
            {
                return "Campo IdFun vazio!";
                //throw new Exception("Campo senha vazio!");
            }
            if (string.IsNullOrWhiteSpace(obj.Banco))
            {
                return "Campo Banco vazio!";
                //throw new Exception("Campo senha vazio!");
            }
            if (string.IsNullOrWhiteSpace(obj.Conta))
            {
                return "Campo Conta vazio!";
                //throw new Exception("Campo senha vazio!");
            }
            if (string.IsNullOrWhiteSpace(obj.Agencia))
            {
                return "Campo Agência vazio!";
                //throw new Exception("Campo senha vazio!");
            }
            
           return Funcionario_DAL.Cadastrar(obj);
        }

        public static Funcionario_DTO ValidarBusc(string cpf)
        {
            if(string.IsNullOrWhiteSpace(cpf))
            {
                throw new Exception("Campo CPF vazio!");
            }
            return Funcionario_DAL.RetornaBusc(cpf);
        }
        public static string ValidarAlteracao(Funcionario_DTO obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Nome))
            {
                return "Campo nome vazio!";
            }
            if (string.IsNullOrWhiteSpace(obj.Rg))
            {
                return "Campo RG vazio!";
            }
            if (string.IsNullOrWhiteSpace(obj.Tel))
            {
                return "Campo Telefone vazio!";
            }
            if (string.IsNullOrWhiteSpace(obj.Cpf))
            {
                return "Campo Cpf vazio!";
            }
            if (string.IsNullOrWhiteSpace(obj.Endereco))
            {
                return "Campo Endereço vazio!";
            }
            if (string.IsNullOrWhiteSpace(obj.IdFun))
            {
                return "Campo IdFun vazio!";
            }
            if (string.IsNullOrWhiteSpace(obj.Banco))
            {
                return "Campo Banco vazio!";
            }
            if (string.IsNullOrWhiteSpace(obj.Conta))
            {
                return "Campo Conta vazio!";
            }
            if (string.IsNullOrWhiteSpace(obj.Agencia))
            {
                return "Campo Agência vazio!";
            }
            return Funcionario_DAL.AlterarFuncionario(obj);

        }


    }
}
