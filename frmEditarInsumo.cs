using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SupplyFlow.frmCadInsumo;
using static SupplyFlow.frmRelQuantidade;

namespace SupplyFlow
{
    public partial class frmEditarInsumo : Form
    {
        private Admin admin;
        private int idUsuario, id;
        private string cargo;
        public frmEditarInsumo(Admin admin, int idUsuario, string cargo)
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

        private void frmEditarInsumo_Load(object sender, EventArgs e)
        {
            try
            {
                string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";
                string query = "SELECT idProduto,descrição FROM produto";
                string query2 = "SELECT idPrato, nome FROM cardapio";

                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        lboProduto.Items.Clear();

                        while (reader.Read())
                        {
                            lboProduto.Items.Add(new Produto2
                            {
                                Id = reader.GetInt32("idProduto"),
                                Desc = reader.GetString("descrição")
                            });
                        }
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query2, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        lboCardapio.Items.Clear();

                        while (reader.Read())
                        {
                            lboCardapio.Items.Add(new Cardapio2
                            {
                                Id = reader.GetInt32("idPrato"),
                                Nome = reader.GetString("nome")
                            });
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
                MessageBox.Show("Id vazio. Preencha com dados para editar o insumo!");
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

                        string sql = "SELECT quantidade_produto, idProduto, idPrato from Insumos WHERE idInsumo = @id";

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
                                    txtQtd.Text = Convert.ToString(reader.GetInt32("quantidade_produto"));
                                    int idPrato = reader.GetInt32("idPrato");
                                    int idProduto = reader.GetInt32("idProduto");

                                    foreach (Cardapio2 item in lboCardapio.Items)
                                    {
                                        if (item.Id == idPrato)
                                        {
                                            lboCardapio.SelectedItem = item;
                                            break;
                                        }
                                    }

                                    foreach (Produto2 item in lboProduto.Items)
                                    {
                                        if (item.Id == idProduto)
                                        {
                                            lboProduto.SelectedItem = item;
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

        public class Produto2
        {
            public int Id { get; set; }
            public string Desc { get; set; }

            public override string ToString()
            {
                return Desc; // A ListBox mostra só o nome
            }
        }

        public class Cardapio2
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
            if (txtId.Text == "" || txtQtd.Text == "" || lboProduto.SelectedItem == null || lboCardapio.SelectedItem == null)
            {
                MessageBox.Show("Campos vazios. Preencha com dados para editar o insumo!");
                return;
            }
            else
            {
                int qtd, idProduto = 0, idPrato = 0;
                try
                {
                    id = Convert.ToInt16(txtId.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("ID preenchido com caracteres! Retire e preencha com números e tente novamente.");
                    return;
                }
                try
                {
                    qtd = Convert.ToInt16(txtQtd.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Preço preenchido com caracteres! Retire e preencha com números e tente novamente.");
                    return;
                }
                if (lboProduto.SelectedItem is Produto2 p)
                {
                    idProduto = p.Id;
                }
                if (lboCardapio.SelectedItem is Cardapio2 c)
                {
                    idPrato = c.Id;
                }
                try
                {
                    ClasseInsumo insumo = new ClasseInsumo(qtd, idProduto, idPrato);
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
            txtQtd.Clear();
            lboCardapio.ClearSelected();
            lboProduto.ClearSelected();
            txtId.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}
