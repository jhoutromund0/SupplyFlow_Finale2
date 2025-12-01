using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SupplyFlow.frmCadInsumo;
using static SupplyFlow.frmEditarInsumo;
using static SupplyFlow.frmRelQuantidade;

namespace SupplyFlow
{
    public partial class frmEditarItemVenda : Form
    {
        private Admin admin;
        private int idUsuario;
        private string cargo;
        private string categoria;
        private int id;
        public frmEditarItemVenda(Admin admin, int idUsuario, string cargo)
        {
            InitializeComponent();
            this.admin = admin;
            this.idUsuario = idUsuario;
            this.cargo = cargo;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmGerente gerente = new frmGerente(admin, idUsuario, cargo);
            gerente.Show();
            this.Close();
        }

        private void frmEditarItemVenda_Load(object sender, EventArgs e)
        {
            rdbPrato.Checked = true;
        }

        private void rdbAperitivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAperitivo.Checked)
            {
                categoria = "Aperitivo";
                carregarLista();
            }
        }

        private void rdbPrato_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPrato.Checked)
            {
                categoria = "Prato Principal";
                carregarLista();
            }
        }

        private void rdbSobremesa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSobremesa.Checked)
            {
                categoria = "Sobremesa";
                carregarLista();
            }
        }

        private void rdbEntrada_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEntrada.Checked)
            {
                categoria = "Entrada";
                carregarLista();
            }
        }

        private void rdbBebida_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBebida.Checked)
            {
                categoria = "Bebida";
                carregarLista();
            }
        }

        public void carregarLista()
        {
            if (rdbAperitivo.Checked) categoria = "Aperitivo";
            else if (rdbBebida.Checked) categoria = "Bebida";
            else if (rdbEntrada.Checked) categoria = "Entrada";
            else if (rdbPrato.Checked) categoria = "Prato Principal";
            else if (rdbSobremesa.Checked) categoria = "Sobremesa";
            try
            {
                string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";
                string query = "SELECT idPrato, nome, categoria FROM cardapio WHERE categoria = @categoria";

                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@categoria", categoria);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            lboCardapio.Items.Clear();

                            while (reader.Read())
                            {
                                lboCardapio.Items.Add(new Cardapio4
                                {
                                    Id = reader.GetInt32("idPrato"),
                                    Nome = reader.GetString("nome")
                                });
                            }
                        }
                    }
                }
            }
            catch (MySqlException erro)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Erro Banco!");
                sb.AppendLine(erro.GetType().ToString());
                sb.AppendLine(erro.Message);
                sb.AppendLine("\n" + erro.StackTrace);

                MessageBox.Show(sb.ToString());
            }
            //tratamento dos demais erros que possam ocorrer
            catch (Exception erro)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Exceção Desconhecida !!!");
                sb.AppendLine(erro.GetType().ToString());
                sb.AppendLine(erro.Message);
                sb.AppendLine("\n" + erro.StackTrace);

                MessageBox.Show(sb.ToString());
            }
        }

        private void btnId_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("O ID do produto está vazio. por favor preencha corretamente!");
                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt32(txtId.Text);

                    string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";
                    using (var connection = new MySqlConnection(conexao))
                    {
                        connection.Open();

                        string sql = "SELECT quantidade, idVenda, idPrato from Itens_venda WHERE idItensVenda = @id";

                        using (var cmd = new MySqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader == null)
                                {
                                    throw new idNaoEncontradoException();
                                }
                                while (reader.Read())
                                {
                                    txtQtd.Text = Convert.ToString(reader.GetInt32("quantidade"));
                                    txtIDVenda.Text = reader.GetInt32("idVenda").ToString();
                                    int idPrato = reader.GetInt32("idPrato");

                                    foreach (Cardapio4 item in lboCardapio.Items)
                                    {
                                        if (item.Id == idPrato)
                                        {
                                            lboCardapio.SelectedItem = item;
                                            break;
                                        }
                                    }
                                }
                                ;
                            }
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Preenchida o ID com caracteres.\nRemova os caracteres e preencha com números!");
                    return;
                }
                catch (idNaoEncontradoException)
                {
                    MessageBox.Show("ID não encontrado no Banco de Dados.\nPreencha com outro ID existente!");
                    return;
                }
            }
        }

        public class Cardapio4
        {
            public int Id { get; set; }
            public string Nome { get; set; }

            public override string ToString()
            {
                return Nome; // A ListBox mostra só o nome
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtQtd.Text == "" || txtIDVenda.Text == "" || lboCardapio.SelectedItem == null)
            {
                MessageBox.Show("Campos vazios!. Por favor preencha corretamente!");
                return;
            }
            else
            {
                int id, qtd, idVenda, idPrato = 0;
                try
                {
                    id = Convert.ToInt32(txtId.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Preço preenchido com caracteres! Retire e preencha com números e tente novamente.");
                    return;
                }
                try
                {
                    qtd = Convert.ToInt32(txtQtd.Text);
                }
                catch (FormatException){
                    MessageBox.Show("Quantidade preenchida com caracteres! Retire e preencha com números e tente novamente.");
                    return;
                }
                try
                {
                    idVenda = Convert.ToInt32(txtIDVenda.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("IDVenda preenchida com caracteres! Retire e preencha com números e tente novamente.");
                    return;
                }
                if (lboCardapio.SelectedItem is Cardapio4 c)
                {
                    idPrato = c.Id;
                }
                try
                {
                    ClasseInsumo insumo = new ClasseInsumo(qtd, idVenda, idPrato);
                    admin.editarInsumo(insumo, id);
                    MessageBox.Show("Produto atualizado com sucesso!");
                    Limpar();
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
            }
        }

        public void Limpar()
        {
            txtId.Clear();
            txtIDVenda.Clear();
            txtQtd.Clear();
            lboCardapio.ClearSelected();
            txtId.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblId_Click(object sender, EventArgs e)
        {

        }
    }
}
