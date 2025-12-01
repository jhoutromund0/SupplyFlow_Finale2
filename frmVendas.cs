using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SupplyFlow
{
    public partial class frmVendas : Form
    {
        private Admin admin;
        private int idUsuario;
        private string cargo;
        public frmVendas(Admin admin, int idUsuario, string cargo)
        {
            InitializeComponent();
            this.admin = admin;
            this.idUsuario = idUsuario;
            this.cargo = cargo;
        }

        private void btnRealizarVenda_Click(object sender, EventArgs e)
        {
            frmCadVenda RealizarVenda = new frmCadVenda(admin, idUsuario, cargo);
            RealizarVenda.Show();
            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVisualizarVenda_Click(object sender, EventArgs e)
        {
            frmVendasGarcom vendasGarcom = new frmVendasGarcom(admin, idUsuario, cargo);
            vendasGarcom.Show();
            this.Close();
        }

        private void btnCardapio_Click(object sender, EventArgs e)
        {
            frmCardapio cardapio = new frmCardapio(admin, idUsuario, cargo);
            cardapio.Show();
            this.Close();

        }

        private void btnEditarVenda_Click(object sender, EventArgs e)
        {
            frmEditarVenda editarVenda = new frmEditarVenda(admin, idUsuario, cargo);
            editarVenda.Show();
            this.Close();
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            frmCadPagamento pagamento = new frmCadPagamento(admin, idUsuario, cargo);
            pagamento.Show();
            this.Close();
        }

        private void btnVoltarGerente_Click(object sender, EventArgs e)
        {
            frmGerente gerente = new frmGerente(admin, idUsuario, cargo);
            gerente.Show();
            this.Close();
        }

        private void frmVendas_Load(object sender, EventArgs e)
        {
            if (cargo == "gerente")
            {
                btnVoltarGerente.Visible = true;
            }
        }

        private void btnProdQuant_Click(object sender, EventArgs e)
        {
            frmRelQuantidade prodQuant = new frmRelQuantidade();
            prodQuant.ShowDialog();
        }

        private void btnCadItemVenda_Click(object sender, EventArgs e)
        {
            frmCadItemVenda itemVenda = new frmCadItemVenda(admin, idUsuario, cargo);
            itemVenda.Show();
            this.Close();
        }

        private void btnEditarItemvenda_Click(object sender, EventArgs e)
        {
            frmEditarItemVenda editItemV = new frmEditarItemVenda(admin, idUsuario, cargo);
            editItemV.Show();
            this.Close();
        }
    }
}
