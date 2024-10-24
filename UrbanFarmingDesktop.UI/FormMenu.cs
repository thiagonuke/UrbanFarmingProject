using System;
using System.Windows.Forms;

namespace UrbanFarmingDesktop.UI
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            CreateMenuButtons();
        }

        private void CreateMenuButtons()
        {
            // Botão para Cadastro de Fornecedor
            Button btnFornecedor = new Button
            {
                Text = "Cadastro de Fornecedor",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(200, 50)
            };
            btnFornecedor.Click += BtnFornecedor_Click;

            // Botão para Cadastro de Produto
            Button btnProduto = new Button
            {
                Text = "Cadastro de Produto",
                Location = new System.Drawing.Point(20, 80),
                Size = new System.Drawing.Size(200, 50)
            };
            btnProduto.Click += BtnProduto_Click;

            // Botão para Cadastro de Pedidos
            Button btnPedidos = new Button
            {
                Text = "Cadastro de Pedidos",
                Location = new System.Drawing.Point(20, 140),
                Size = new System.Drawing.Size(200, 50)
            };
            btnPedidos.Click += BtnPedidos_Click;

            // Botão para Login
            Button btnLogin = new Button
            {
                Text = "Login",
                Location = new System.Drawing.Point(20, 200),
                Size = new System.Drawing.Size(200, 50)
            };
            btnLogin.Click += BtnLogin_Click;

            // Adicionando os botões ao formulário
            Controls.Add(btnFornecedor);
            Controls.Add(btnProduto);
            Controls.Add(btnPedidos);
            Controls.Add(btnLogin);
        }

        private void BtnFornecedor_Click(object sender, EventArgs e)
        {
            FormFornecedor formFornecedor = new FormFornecedor();
            formFornecedor.ShowDialog();
        }

        private void BtnProduto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir cadastro de produtos (implementação a fazer).");
        }

        private void BtnPedidos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir cadastro de pedidos (implementação a fazer).");
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir tela de login (implementação a fazer).");
        }
    }
}
