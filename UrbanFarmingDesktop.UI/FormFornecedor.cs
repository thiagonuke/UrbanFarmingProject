using System;
using System.Windows.Forms;

namespace UrbanFarmingDesktop.UI
{
    public partial class FormFornecedor : Form
    {
        public FormFornecedor()
        {
            InitializeComponent();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var isJuridica = radioButtonJuridica.Checked;
            campoCNPJ.Visible = isJuridica;
            campoCPF.Visible = !isJuridica;
        }

        private void inputCNPJ_Leave(object sender, EventArgs e)
        {
            var cnpj = inputCNPJ.Text;
            if (cnpj.Length == 14)
            {
                // Simulação de preenchimento:
                inputRazaoSocial.Text = "Nome da Razão Social"; // Exemplo
                inputNomeFantasia.Text = "Nome Fantasia"; // Exemplo
                // Aqui você pode implementar a chamada AJAX para a API de CNPJ
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Aqui você pode implementar o cadastro do fornecedor
            MessageBox.Show("Cadastro realizado com sucesso!");
        }
    }
}
