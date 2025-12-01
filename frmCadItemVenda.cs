using MySql.Data.MySqlClient;
using Mysqlx;
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
using static SupplyFlow.frmRelQuantidade;

namespace SupplyFlow
{
    public partial class frmCadItemVenda : Form
    {
        private Admin admin;
        private int idUsuario;
        private string cargo;
        private string categoria;
        public frmCadItemVenda(Admin admin, int idUsuario, string cargo)
        {
            InitializeComponent();
            this.admin = admin;
            this.idUsuario = idUsuario;
            this.cargo = cargo;
        }

        public void Limpar()
        {
            txtIDVenda.Clear();
            txtQtd.Clear();
            rdbPrato.Checked = true;
            lboCardapio.ClearSelected();
            txtQtd.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmVendas garcom = new frmVendas(admin, idUsuario, cargo);
            garcom.Show();
            this.Close();
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

        private void frmCadItemVenda_Load(object sender, EventArgs e)
        {
            rdbPrato.Checked = true;
            carregarLista();
        }

        public void carregarLista()
        {
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
                                    lboCardapio.Items.Add(new Cardapio2
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
        private void rdbAperitivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAperitivo.Checked)
            {
                categoria = "Aperitivo";
                carregarLista();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int quantidade = 0, idVenda = 0, idPrato = 0;

            if (txtIDVenda.Text == "" || txtQtd.Text == "" || lboCardapio.SelectedItem == null)
            {
                MessageBox.Show("Alguns dos campos não foram preenchdos. Preencha todos para cadastrar o Item da Venda!");
                return;
            }

            try
            {
                quantidade = Convert.ToInt16(txtQtd.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Caracter encontrado na quantidade. Retirar caractere para continuar o cadastro!");
            }
            if (lboCardapio.SelectedItem is Cardapio2 c)
            {
                idPrato = c.Id;
            }

            try
            {
                idVenda = Convert.ToInt16(txtIDVenda.Text);

                string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";
                using (var connection = new MySqlConnection(conexao))
                {
                    connection.Open();

                    string sql = "SELECT idItensVenda FROM itens_venda WHERE idItensVenda = @id";

                    using (var cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", idVenda);

                        object result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            throw new idNaoEncontradoException();
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

            try
            {
                ClasseItemVenda itemVenda = new ClasseItemVenda(quantidade, idVenda, idPrato);
                admin.cadastrarItemVenda(itemVenda);
                MessageBox.Show("Item da Venda cadastrado com sucesso!");
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
            Limpar();
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
            categoria = "Sobremesa";
            carregarLista();
        }

        private void rdbEntrada_CheckedChanged(object sender, EventArgs e)
        {
            categoria = "Entrada";
            carregarLista();
        }

        private void rdbBebida_CheckedChanged(object sender, EventArgs e)
        {
            categoria = "Bebida";
            carregarLista();
        }
    }
}