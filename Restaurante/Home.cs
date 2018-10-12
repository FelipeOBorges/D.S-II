using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_Restaurante;
using BLL_Restaurante;

namespace UI_Restaurante
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            btnAlterarFunc.Enabled = false;
            btnAlterarProd.Enabled = false;
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastroFunc_Click(object sender, EventArgs e)
        {
            try
            {
                Funcionario_DTO obj = new Funcionario_DTO(); 
                obj.Nome = txtNomeFun.Text; 
                obj.Rg = txtRgFunc.Text; 
                obj.Tel = txtTelefoneFunc.Text;
                obj.Cpf = txtCpfFunc.Text;
                obj.Endereco = txtEndFunc.Text;
                obj.IdFun = txtIdFunc.Text;
                obj.Banco = txtBancoFunc.Text;
                obj.Conta = txtBancoFunc.Text;
                obj.Agencia = txtAgenciaFunc.Text;
                string retorno; 
                retorno = Funcionario_BLL.ValidarFunc(obj);
                if (retorno == "sucesso")
                {
                    MessageBox.Show(retorno, "Funcionário cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtNomeFun.Clear();
                    txtRgFunc.Clear();
                    txtTelefoneFunc.Clear();
                    txtCpfFunc.Clear();
                    txtEndFunc.Clear();
                    txtIdFunc.Clear();
                    txtBancoFunc.Clear();
                    txtContaFunc.Clear();
                    txtAgenciaFunc.Clear();
                }
                else
                {
                    MessageBox.Show(retorno, "Funcionário não cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void txtUniMeProd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtEstoqueProd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtTipoProd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecoProd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProdPro_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtCodProd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscasFunc_Click(object sender, EventArgs e)
        {
            try
            {
                string CPF;
                CPF = txtCpfFunc.Text;
                Funcionario_DTO BuscFun = new Funcionario_DTO();
                BuscFun = Funcionario_BLL.ValidarBusc(CPF);
                txtNomeFun.Text = BuscFun.Nome;
                txtRgFunc.Text = BuscFun.Rg;
                txtTelefoneFunc.Text = BuscFun.Tel;
                txtCpfFunc.Text = BuscFun.Cpf;
                txtEndFunc.Text = BuscFun.Endereco;
                txtIdFunc.Text = BuscFun.IdFun;
                txtBancoFunc.Text = BuscFun.Banco;
                txtContaFunc.Text = BuscFun.Conta;
                txtAgenciaFunc.Text = BuscFun.Agencia;
                btnAlterarFunc.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlterarFunc_Click(object sender, EventArgs e)
        {
            Funcionario_DTO obj = new Funcionario_DTO();
            obj.Nome = txtNomeFun.Text;
            obj.Rg = txtRgFunc.Text;
            obj.Tel = txtTelefoneFunc.Text;
            obj.Cpf = txtCpfFunc.Text;
            obj.Endereco = txtEndFunc.Text;
            obj.IdFun = txtIdFunc.Text;
            obj.Banco = txtBancoFunc.Text;
            obj.Conta = txtContaFunc.Text;
            obj.Agencia = txtAgenciaFunc.Text;
            string retornoalt = Funcionario_BLL.ValidarAlteracao(obj);
            MessageBox.Show(retornoalt, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNomeFun.Clear();
            txtRgFunc.Clear();
            txtTelefoneFunc.Clear();
            txtCpfFunc.Clear();
            txtEndFunc.Clear();
            txtIdFunc.Clear();
            txtBancoFunc.Clear();
            txtContaFunc.Clear();
            txtAgenciaFunc.Clear();
            btnAlterarFunc.Enabled = false;
        }

        private void btnBuscarProd_Click(object sender, EventArgs e)
        {
            try
            {
                string PRODUTO;
                PRODUTO = txtProdPro.Text;
                Produto__DTO BuscProduto = new Produto__DTO();
                BuscProduto = Produto_BLL.ValidarBuscaProduto(PRODUTO);
                txtCodProd.Text = BuscProduto.Codigo;
                txtPrecoProd.Text = BuscProduto.Preco;
                txtEstoqueProd.Text = BuscProduto.Estoque;
                txtTipoProd.Text = BuscProduto.Tipo;
                txtUniMeProd.Text = BuscProduto.Uni_media;
                btnAlterarProd.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrarProd_Click(object sender, EventArgs e)
        {
            try
            {
                Produto__DTO obj = new Produto__DTO();
                obj.Produto = txtProdPro.Text;
                obj.Codigo = txtCodProd.Text;
                obj.Preco = txtPrecoProd.Text;
                obj.Estoque = txtEstoqueProd.Text;
                obj.Tipo = txtTipoProd.Text;
                obj.Uni_media = txtUniMeProd.Text;
                string retorno;
                retorno = Produto_BLL.ValidarProduto(obj);

                if (retorno == "retorno")
                {
                    MessageBox.Show(retorno, "Produto cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show(retorno, "Produto não cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtLimparFunc_Click(object sender, EventArgs e)
        {
            txtNomeFun.Clear();
            txtRgFunc.Clear();
            txtTelefoneFunc.Clear();
            txtCpfFunc.Clear();
            txtEndFunc.Clear();
            txtIdFunc.Clear();
            txtBancoFunc.Clear();
            txtContaFunc.Clear();
            txtAgenciaFunc.Clear();
        }

        private void btnAlterarProd_Click(object sender, EventArgs e)
        {
            Produto__DTO obj = new Produto__DTO();
            obj.Codigo = txtCodProd.Text;
            obj.Produto = txtProdPro.Text;
            obj.Preco = txtPrecoProd.Text;
            obj.Estoque = txtEstoqueProd.Text;
            obj.Tipo = txtTipoProd.Text;
            obj.Uni_media = txtUniMeProd.Text;
            string retornoalt = Produto_BLL.ValidarAlteracaoProd(obj);
            MessageBox.Show(retornoalt, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtCodProd.Clear();
            txtProdPro.Clear();
            txtPrecoProd.Clear();
            txtEstoqueProd.Clear();
            txtTipoProd.Clear();
            txtUniMeProd.Clear();
            btnBuscarProd.Enabled = false;
        }

        private void txtLimparProd_Click(object sender, EventArgs e)
        {
            txtCodProd.Clear();
            txtProdPro.Clear();
            txtPrecoProd.Clear();
            txtEstoqueProd.Clear();
            txtTipoProd.Clear();
            txtUniMeProd.Clear();
        }
    }
}
