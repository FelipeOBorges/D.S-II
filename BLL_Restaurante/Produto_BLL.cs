using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Restaurante;
using DTO_Restaurante;

namespace BLL_Restaurante
{
    public class Produto_BLL
    {
        public static string ValidarProduto(Produto__DTO obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Codigo))
            {
                return "Código do produto vazio!";
            }
            bool teste_produto = Produto_DAL.PesquisarProduto(obj.Produto);
            if (teste_produto == true)
            {
                return "Produto já existe na base de dados!";
            }
            //if (string.IsNullOrWhiteSpace(obj.Produto))
            //{
            //  return "Produto vazio!";
            //}
            if (string.IsNullOrWhiteSpace(obj.Preco))
            {
                return "Preço vazio!";
            }
            if (string.IsNullOrWhiteSpace(obj.Estoque))
            {
                return "Estoque vazio!";
            }
            if (string.IsNullOrWhiteSpace(obj.Tipo))
            {
                return "Tipo do produto vazio!";
            }
            if (string.IsNullOrWhiteSpace(obj.Uni_media))
            {
                return "Unidade de produto vazio!";
            }
            return Produto_DAL.CadastrarProduto(obj);
        }
        public static Produto__DTO ValidarBuscaProduto(string produto)
        {
            if (string.IsNullOrWhiteSpace(produto))
            {
                throw new Exception("Nome do Produto é necessário para buscar o produto!");
            }
            return Produto_DAL.RetornaBuscaProduto(produto);
        }
        public static string ValidarAlteracaoProd(Produto__DTO obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Codigo))
            {
                return "Código do produto vazio!";
            }
            if (string.IsNullOrWhiteSpace(obj.Produto))
            {
                return "Produto vazio!";
            }
            if (string.IsNullOrWhiteSpace(obj.Preco))
            {
                return "Preço vazio!";
            }
            if (string.IsNullOrWhiteSpace(obj.Estoque))
            {
                return "Estoque vazio!";
            }
            if (string.IsNullOrWhiteSpace(obj.Tipo))
            {
                return "Tipo do produto vazio!";
            }
            if (string.IsNullOrWhiteSpace(obj.Uni_media))
            {
                return "Unidade de produto vazio!";
            }
            return Produto_DAL.AlterarProduto(obj);
        }
    }
}
