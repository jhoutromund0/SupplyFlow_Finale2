using MySql.Data.MySqlClient;
using SupplyFlow;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupplyFlow
{
    public partial class frmEditarProduto : Form
    {
        private Admin admin;
        private int idUsuario;
        private string cargo;

        private readonly string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";
        private bool modoEdicao = false;
        private int produtoCarregadoId = 0;

        public frmEditarProduto(Admin admin, int idUsuario, string cargo)
        {
            InitializeComponent();
            btnEditar.Text = "Editar";
        }

        // Ao clicar: ssprimeiro carrega pelo ID; se já carregado, salva as alterações
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text.Trim());
            string nome = txtNome.Text.Trim();
            string categoria = txtCategoria.Text.Trim();
            int qtdStr = int.Parse(txtQtd.Text.Trim());
            int qtdIdealStr = int.Parse(txtQtdIdeal.Text.Trim());
            string uniMed = txtUniMed.Text.Trim();
            //double precoStr = double.Parse(mtxtPreco.Text());
            UpdateProduto(id, nome,  categoria, qtdStr, qtdIdealStr,  uniMed);
        }

        public bool UpdateProduto(int idProduto, string nome, string categoria, int qtdStr, int qtdIdeal, string uniMed)
        {
            if (idProduto <= 0) return false;

            try
            {
                using (var conn = new MySqlConnection(conexao))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"
                UPDATE produto
                SET descrição             = @nome,
                    categoria             = @categoria,
                    quantidade_atual      = @qtdStr,
                    quantidade_adequada   = @qtdIdeal,
                    unidade_medida        = @uniMed,
                    
                WHERE idProduto = @idProduto";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@nome", nome ?? string.Empty);
                    cmd.Parameters.AddWithValue("@categoria", categoria ?? string.Empty);
                    cmd.Parameters.AddWithValue("@qtdStr", qtdStr);
                    cmd.Parameters.AddWithValue("@qtdIdeal", qtdIdeal);
                    cmd.Parameters.AddWithValue("@uniMed", uniMed ?? string.Empty);
                    //cmd.Parameters.AddWithValue("@preco", preco);
                    cmd.Parameters.AddWithValue("@idProduto", idProduto);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}