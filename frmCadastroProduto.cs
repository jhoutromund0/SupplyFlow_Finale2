using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SupplyFlow
{
    public partial class frmCadastroProduto : Form
    {
        private Admin admin;
        private int idUsuario;
        private string cargo;
        public frmCadastroProduto(Admin admin, int idUsuario, string cargo)
        {
            this.admin = admin;
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.cargo = cargo;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmEstoque estoque = new frmEstoque(admin, idUsuario, cargo);
            estoque.Show();
            this.Close();
        }

        private void limpar()
        {
            txtCategoria.Clear();
            txtDesc.Clear();
            txtPreco.Clear();
            txtQtd.Clear();
            txtQtdIdeal.Clear();
            txtUniMed.Clear();
            txtDesc.Focus();
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string desc, categoria, uniMed;
            int quantAtual, quantIdeal;
            double preco;

            if (txtCategoria.Text == "" || txtDesc.Text == "" || txtPreco.Text == "" || txtQtd.Text == "" || txtQtdIdeal.Text == "" || txtUniMed.Text == "")
            {
                MessageBox.Show("Alguns dados não foram preenchidos.\nPreencha todos os dados");
                return;
            }

            desc = txtDesc.Text.Trim();
            categoria = txtCategoria.Text.Trim();
            uniMed = txtUniMed.Text.Trim();

            try
            {
                quantAtual = Convert.ToInt16(txtQtd.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("Preenchida a quantidade atual com caracteres.\nRemova os caracteres e preencha com números!");
                return;
            }
            try
            {
                quantIdeal = Convert.ToInt16(txtQtdIdeal.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("Preenchida a quantidade adequada com caracteres.\nRemova os caracteres e preencha com números!");
                return;
            }
            try
            {
                preco = Convert.ToDouble(txtPreco.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("Preenchido o preço de compra com caracteres.\nRemova os caracteres e preencha com números!");
                return;
            }

            try
            {
                ClasseProduto produto = new ClasseProduto(desc, categoria, uniMed, quantAtual, quantIdeal, preco);
                admin.cadastrarProduto(produto);
                MessageBox.Show("Produto cadastrado com sucesso!");

            }
            catch (Exception erro)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Exceção Desconhecida !!!");
                sb.AppendLine(erro.GetType().ToString());
                sb.AppendLine(erro.Message);
                sb.AppendLine("\n" + erro.StackTrace);

                MessageBox.Show(sb.ToString());
            }

            limpar();
        }
    }
}
