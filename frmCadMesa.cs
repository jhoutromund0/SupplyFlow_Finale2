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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SupplyFlow
{
    public partial class frmCadMesa : Form
    {
        private Admin admin;
        private int idUsuario;
        private string cargo;
        public frmCadMesa(Admin admin, int idUsuario, string cargo)
        {
            InitializeComponent();
            this.admin = admin;
            this.idUsuario = idUsuario;
            this.cargo = cargo;
        }

        private void limpar()
        {
            txtNum.Clear();
            txtCapacidade.Clear();
            lboStatus.ClearSelected();
            txtNum.Focus();
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int num, capacidade;
            string status;

            if (txtCapacidade.Text == "" || txtNum == null || lboStatus.SelectedItem == null)
            {
                MessageBox.Show("Alguns dados não foram preenchidos.\nPreencha todos os dados");
                return;
            }

            try
            {
                num = Convert.ToInt16(txtNum.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("Preenchido o número com caracteres.\nRemova os caracteres e preencha com números!");
                return;
            }
            try
            {
                capacidade = Convert.ToInt16(txtCapacidade.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("Preenchida a capacidade com caracteres.\nRemova os caracteres e preencha com números!");
                return;
            }
            status = Convert.ToString(lboStatus.SelectedItem);

            try
            {
                ClasseMesa mesa = new ClasseMesa(num, capacidade, status);
                admin.cadastrarMesa(mesa);
                MessageBox.Show("Mesa cadastrada com sucesso!");
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmGerente gerente = new frmGerente(admin, idUsuario, cargo);
            gerente.Show();
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Conexão (mesma usada em outras telas)
            string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";

            // Modo buscar (carregar dados para edição)
            if (selectedIdMesa == 0)
            {
                if (string.IsNullOrWhiteSpace(txtNum.Text))
                {
                    MessageBox.Show("Informe o número da mesa no campo 'Número' para buscar.");
                    txtNum.Focus();
                    return;
                }

                int numero;
                try
                {
                    numero = Convert.ToInt32(txtNum.Text.Trim());
                }
                catch (FormatException)
                {
                    MessageBox.Show("Número da mesa inválido. Use apenas números.");
                    txtNum.Focus();
                    return;
                }

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(conexao))
                    {
                        conn.Open();
                        string query = "SELECT idMesa, numero, capacidade, status FROM mesa WHERE numero = @numero LIMIT 1";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@numero", numero);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    selectedIdMesa = reader.GetInt32("idMesa");
                                    txtNum.Text = reader.GetInt32("numero").ToString();
                                    txtCapacidade.Text = reader.GetInt32("capacidade").ToString();
                                    string status = reader.IsDBNull(reader.GetOrdinal("status")) ? "" : reader.GetString("status");

                                    // tenta selecionar o item no ListBox que corresponda ao status
                                    bool found = false;
                                    for (int i = 0; i < lboStatus.Items.Count; i++)
                                    {
                                        if (string.Equals(lboStatus.Items[i].ToString(), status, StringComparison.OrdinalIgnoreCase))
                                        {
                                            lboStatus.SelectedIndex = i;
                                            found = true;
                                            break;
                                        }
                                    }
                                    if (!found)
                                    {
                                        lboStatus.ClearSelected();
                                    }

                                    // altera estado para edição
                                    btnEditar.Text = "Salvar";
                                    txtNum.Enabled = true; // permite alterar número se desejar
                                    MessageBox.Show("Dados carregados. Edite os campos e clique em Salvar para aplicar as alterações.");
                                }
                                else
                                {
                                    MessageBox.Show("Mesa não encontrada para o número informado.");
                                }
                            }
                        }
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
            // Modo salvar (atualizar registro já carregado)
            else
            {
                int numero, capacidade;
                string status;

                if (string.IsNullOrWhiteSpace(txtNum.Text) || string.IsNullOrWhiteSpace(txtCapacidade.Text) || lboStatus.SelectedItem == null)
                {
                    MessageBox.Show("Preencha todos os campos antes de salvar a edição.");
                    return;
                }

                try
                {
                    numero = Convert.ToInt32(txtNum.Text.Trim());
                }
                catch (FormatException)
                {
                    MessageBox.Show("Número da mesa inválido. Use apenas números.");
                    txtNum.Focus();
                    return;
                }

                try
                {
                    capacidade = Convert.ToInt32(txtCapacidade.Text.Trim());
                }
                catch (FormatException)
                {
                    MessageBox.Show("Capacidade inválida. Use apenas números.");
                    txtCapacidade.Focus();
                    return;
                }

                status = lboStatus.SelectedItem.ToString();

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(conexao))
                    {
                        conn.Open();
                        string update = @"UPDATE mesa
                                          SET numero = @numero,
                                              capacidade = @capacidade,
                                              status = @status
                                          WHERE idMesa = @idMesa";
                        using (MySqlCommand cmd = new MySqlCommand(update, conn))
                        {
                            cmd.Parameters.AddWithValue("@numero", numero);
                            cmd.Parameters.AddWithValue("@capacidade", capacidade);
                            cmd.Parameters.AddWithValue("@status", status);
                            cmd.Parameters.AddWithValue("@idMesa", selectedIdMesa);

                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                MessageBox.Show("Mesa atualizada com sucesso!");
                                limpar();
                            }
                            else
                            {
                                MessageBox.Show("Nenhuma linha foi atualizada. Verifique se a mesa ainda existe.");
                            }
                        }
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
}           
    

