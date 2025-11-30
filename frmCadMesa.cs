using System;
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
    public partial class frmCadMesa : Form
    {
        private Admin admin;
        private int idUsuario;
        private string cargo;
        public frmCadMesa(Admin admin, int idUsuario, string cargo)
        {
            InitializeComponent();
            this.admin = admin;
            this.idUsuario = idUsuario;
            this.cargo = cargo;
        }

        private void limpar()
        {
            txtNum.Clear();
            txtCapacidade.Clear();
            lboStatus.ClearSelected();
            txtNum.Focus();
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int num, capacidade;
            string status;

            if (txtCapacidade.Text == "" || txtNum == null || lboStatus.SelectedItem == null)
            {
                MessageBox.Show("Alguns dados não foram preenchidos.\nPreencha todos os dados");
                return;
            }

            try
            {
                num = Convert.ToInt16(txtNum.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("Preenchido o número com caracteres.\nRemova os caracteres e preencha com números!");
                return;
            }
            try
            {
                capacidade = Convert.ToInt16(txtCapacidade.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("Preenchida a capacidade com caracteres.\nRemova os caracteres e preencha com números!");
                return;
            }
            status = Convert.ToString(lboStatus.SelectedItem);

            try
            {
                ClasseMesa mesa = new ClasseMesa(num, capacidade, status);
                admin.cadastrarMesa(mesa);
                MessageBox.Show("Mesa cadastrada com sucesso!");
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmGerente gerente = new frmGerente(admin, idUsuario, cargo);
            gerente.Show();
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}
