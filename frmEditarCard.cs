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
using static SupplyFlow.frmCadItemVenda;

namespace SupplyFlow
{
    public partial class frmEditarCard : Form
    {
        private Admin admin;
        private int idUsuario;
        private string cargo;
        public frmEditarCard(Admin admin, int idUsuario, string cargo)
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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if(txtId.Text == "" || txtDesc.Text == "" || txtNome.Text == "" || txtPreco.Text == "" || lboProduto.SelectedItem == null)
            {
                MessageBox.Show("Campos vazios. Digite os campos e tente novamente!");
                return;
            }
            else
            {
                string nome, desc, categoria;
                double preco;
                int id;
                try
                {
                    id = Convert.ToInt32(txtId.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("ID preenchido com caracteres! Retire e preencha com números e tente novamente.");
                    return;
                }
                nome = txtNome.Text;
                desc = txtDesc.Text;
                categoria = Convert.ToString(lboProduto.SelectedItem);
                try
                {
                    preco = Convert.ToDouble(txtPreco.Text);
                }
                catch
                {
                    MessageBox.Show("Preço preenchido com caracteres! Retire e preencha com números e tente novamente.");
                    return;
                }

                try
                {
                    ClasseCardapio cardapio = new ClasseCardapio(nome, desc, categoria, preco);
                    admin.editarCardapio(cardapio, id);
                    MessageBox.Show("Produto atualizado com sucesso!");
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
            txtNome.Clear();
            txtDesc.Clear();
            txtPreco.Clear();
            lboProduto.ClearSelected();
            txtId.Focus();
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }


        private void btnId_Click(object sender, EventArgs e)
        {
            int id;
            if (txtId.Text == "")
            {
                MessageBox.Show("ID não prenchido. Preencha com algum valor!");
                return;
            }
            try
            {
                id = Convert.ToInt32(txtId.Text);

                string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";
                using (var connection = new MySqlConnection(conexao))
                {
                    connection.Open();

                    string sql = "SELECT nome, descrição, preço, categoria FROM cardapio WHERE idPrato = @id";

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
                                txtNome.Text = reader.GetString("nome");
                                txtDesc.Text = reader.GetString("descrição");
                                txtPreco.Text = Convert.ToString(reader.GetDouble("preço"));
                                lboProduto.SelectedItem = reader.GetString("categoria");
                            };
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
}
