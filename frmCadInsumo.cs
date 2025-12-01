using MySql.Data.MySqlClient;
using Mysqlx;
using Org.BouncyCastle.Tls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SupplyFlow.frmCadItemVenda;

namespace SupplyFlow
{
    public partial class frmCadInsumo : Form
    {
        private Admin admin;
        private int idUsuario;
        private string cargo;
        private string categoria;
        public frmCadInsumo(Admin admin, int idUsuario, string cargo)
        {
            InitializeComponent();
            this.admin = admin;
            this.idUsuario = idUsuario;
            this.cargo = cargo;
        }

        private void limpar() 
        {
            txtQtd.Clear();
            lboCardapio.ClearSelected();
            lboProduto.ClearSelected();
            txtQtd.Focus();
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();   
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int qtd, idProduto = 0, idCardapio = 0;

            if (Convert.ToString(lboCardapio.SelectedItem) == "" || Convert.ToString(lboProduto.SelectedItem) == "" || txtQtd.Text == "")
            {
                MessageBox.Show("Alguns dados não foram preenchidos.\nPreencha todos os dados");
                return;
            }

            try
            {
                qtd = Convert.ToInt16(txtQtd.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("Preenchida a quantidade com caracteres.\nRemova os caracteres e preencha com números!");
                return;
            }

            if (lboProduto.SelectedItem is Produto p)
            {
                idProduto = p.Id;
            }
            if (lboCardapio.SelectedItem is Cardapio c)
            {
                idCardapio = c.Id;
            }

            try
            {
                ClasseInsumo insumo = new ClasseInsumo(qtd, idProduto, idCardapio);
                admin.cadastrarInsumo(insumo);
                MessageBox.Show("Insumo cadastrado com sucesso!");

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

        public class Produto
        {
            public int Id { get; set; }
            public string Desc { get; set; }

            public override string ToString()
            {
                return Desc; // A ListBox mostra só o nome
            }
        }

        public class Cardapio
        {
            public int Id { get; set; }
            public string Nome { get; set; }

            public override string ToString()
            {
                return Nome; // A ListBox mostra só o nome
            }
        }
        private void frmCadInsumo_Load(object sender, EventArgs e)
        {
            rdbPrato.Checked = true;
                try
                {
                    string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";
                    string query = "SELECT idProduto,descrição FROM produto";

                    using (MySqlConnection conn = new MySqlConnection(conexao))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            lboProduto.Items.Clear();

                            while (reader.Read())
                            {
                                lboProduto.Items.Add(new Produto
                                {
                                    Id = reader.GetInt32("idProduto"),
                                    Desc = reader.GetString("descrição")
                                });
                            }
                        }
                    }
                    carregarLista();
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
        

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmGerente gerente = new frmGerente(admin, idUsuario, cargo);
            gerente.Show();
            this.Close();
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
                                lboCardapio.Items.Add(new Cardapio
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
    }
}
