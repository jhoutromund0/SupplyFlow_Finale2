using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupplyFlow
{
    public partial class frmGerente : Form
    {
        private Admin admin;
        private int idUsuario;
        private string cargo;
        public frmGerente(Admin admin, int idUsuario, string cargo)
        {
            InitializeComponent();
            this.admin = admin;
            this.idUsuario = idUsuario;
            this.cargo = cargo;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastrarFunc_Click(object sender, EventArgs e)
        {
            frmCadastroFunc cadFunc = new frmCadastroFunc(admin, idUsuario, cargo);
            cadFunc.Show();
            this.Close();
        }

        private void btnCardapio_Click(object sender, EventArgs e)
        {
            frmCadCardapio cardapio = new frmCadCardapio(admin, idUsuario, cargo);
            cardapio.Show();
            this.Close();
        }

        private void btnInsumo_Click(object sender, EventArgs e)
        {
            frmCadInsumo insumo = new frmCadInsumo(admin, idUsuario, cargo);
            insumo.Show();
            this.Close();
        }

        private void btnCadMesa_Click(object sender, EventArgs e)
        {
            frmCadMesa mesa = new frmCadMesa(admin, idUsuario, cargo);
            mesa.Show();
            this.Close();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            frmVendas vendas = new frmVendas(admin, idUsuario, cargo);
            vendas.Show();
            this.Close();
        }

        private void frmGerente_Load(object sender, EventArgs e)
        {

        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            frmEstoque estoque = new frmEstoque(admin, idUsuario, cargo);
            estoque.Show();
            this.Close();
        }

        private void btnRelatorioVendas_Click(object sender, EventArgs e)
        {
            frmRelatoriosVenda relVenda = new frmRelatoriosVenda(admin, idUsuario, cargo);
            relVenda.Show();
            this.Close();
        }

        private void btnEditarCard_Click(object sender, EventArgs e)
        {
            frmEditarCard editarCardapio = new frmEditarCard(admin, idUsuario, cargo);
            editarCardapio.Show();
            this.Close();
        }

        private void btnEditarInsumo_Click(object sender, EventArgs e)
        {
            frmEditarInsumo editInsumo = new frmEditarInsumo(admin, idUsuario, cargo);
            editInsumo.Show();
            this.Close();
        }

        private void btnEditarFunc_Click(object sender, EventArgs e)
        {
            frmEditarFunc editFunc = new frmEditarFunc(admin, idUsuario, cargo);
            editFunc.Show();
            this.Close();
        }
    }
}
