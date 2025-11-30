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
    public partial class frmCardapio : Form
    {
        private Admin admin;
        private int idUsuario;
        private string cargo;
        public frmCardapio(Admin admin, int idUsuario, string cargo)
        {
            InitializeComponent();
            this.admin = admin;
            this.idUsuario = idUsuario;
            this.cargo = cargo;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmVendas vendas = new frmVendas(admin, idUsuario, cargo);
            vendas.Show();
            this.Close();
        }
    }
}
