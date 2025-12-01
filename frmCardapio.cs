using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


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

        public class CardapioItem
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public string Categoria { get; set; }
            public double? Preco { get; set; }

            public override string ToString()
            {
                // Formatação centralizada para exibição no ListBox
                var precoStr = Preco.HasValue ? Preco.Value.ToString("C2") : "—";
                return $"{Nome} ({Categoria}) - {precoStr}\n{Descricao}";
            }
        }

        private void frmCardapio_Load(object sender, EventArgs e)
        {

            try
            {
                string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";
                string query = @"SELECT idPrato, 
                                        nome, 
                                        `descrição` AS descricao, 
                                        `preço` AS preco, 
                                    categoria FROM cardapio";

                var lista = new List<CardapioItem>();

                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new CardapioItem
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("idPrato")),
                                Nome = reader.IsDBNull(reader.GetOrdinal("nome")) ? string.Empty : reader.GetString("nome"),
                                Descricao = reader.IsDBNull(reader.GetOrdinal("descricao")) ? string.Empty : reader.GetString("descricao"),
                                Categoria = reader.IsDBNull(reader.GetOrdinal("categoria")) ? string.Empty : reader.GetString("categoria"),
                                Preco = reader.IsDBNull(reader.GetOrdinal("preco")) ? (double?)null : reader.GetDouble(reader.GetOrdinal("preco"))
                            };
                            lista.Add(item);
                        }
                    }
                }

                // Adiciona objetos ao ListBox; ToString() controla a exibição
                foreach (var i in lista)
                {
                    lboCardapio.Items.Add(i);
                }
            }
            catch (MySqlException erro)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Erro Banco!");
                sb.AppendLine(erro.GetType().ToString());
                sb.AppendLine(erro.Message);
                sb.AppendLine("\n" + erro.StackTrace);
                MessageBox.Show(sb.ToString());
            }
            catch (Exception erro)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Exceção Desconhecida !!!");
                sb.AppendLine(erro.GetType().ToString());
                sb.AppendLine(erro.Message);
                sb.AppendLine("\n" + erro.StackTrace);
                MessageBox.Show(sb.ToString());
            }
        }
    }
}
