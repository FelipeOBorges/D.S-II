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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtEntrar_Click(object sender, EventArgs e)
        {
            

            try
            {
                Login_DTO obj = new Login_DTO(); //Cria o objeto para receber os valores das caixas de Texto.
                obj.Usuario = txtUser.Text; //Objeto recebendo o valor na propriedade Text.
                obj.Senha = txtSenha.Text; //Objeto recebendo o valor na propriedade Text.
                string retorno; //Criando a variavel.
                retorno = Login_BLL.ValidarLogin(obj); //Variavel recebendo o objeto da Classe Bll validada.
                if (retorno == "sucesso")
                {
                    this.Hide();
                    Home tela = new Home();
                    tela.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(retorno, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Identar código automáticamente = CTRL + K + D.
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
