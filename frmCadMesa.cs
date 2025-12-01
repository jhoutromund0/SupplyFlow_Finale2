using System;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SupplyFlow
{
    public partial class frmCadMesa : Form
    {
        private Admin admin;
        private int idUsuario;
        private string cargo;

        // controle dinâmico para receber o id/pedido da mesa
        private TextBox txtPedido;
        private Label lblPedido;

        public frmCadMesa(Admin admin, int idUsuario, string cargo)
        {
            InitializeComponent();
            this.admin = admin;
            this.idUsuario = idUsuario;
            this.cargo = cargo;

            // cria textbox/label dinamicamente para o "pedido (id da mesa)"
            lblPedido = new Label
            {
                Text = "ID Mesa:",
                AutoSize = true,
                Location = new System.Drawing.Point(12, 70) // ajuste caso necessário
            };
            txtPedido = new TextBox
            {
                Name = "txtPedido",
                Location = new System.Drawing.Point(lblPedido.Right + 6, lblPedido.Top - 3),
                Size = new System.Drawing.Size(80, 22)
            };
            // evento: ao perder foco tenta preencher automaticamente
            txtPedido.Leave += TxtPedido_Leave;

            // adiciona aos controles do formulário
            this.Controls.Add(lblPedido);
            this.Controls.Add(txtPedido);

            // Estado inicial: campos editáveis normalmente (fluxo simples)
            SetFieldsEditableMesa(true);
        }

        private void limpar()
        {
            txtNum.Clear();
            txtCapacidade.Clear();
            lboStatus.ClearSelected();
            txtNum.Focus();

            // limpa textbox de pedido, se existir
            if (txtPedido != null)
                txtPedido.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int num, capacidade;
            string status;

            if (string.IsNullOrWhiteSpace(txtNum.Text) || string.IsNullOrWhiteSpace(txtCapacidade.Text) || lboStatus.SelectedItem == null)
            {
                MessageBox.Show("Alguns dados não foram preenchidos.\nPreencha todos os dados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                num = Convert.ToInt16(txtNum.Text.Trim());
                capacidade = Convert.ToInt16(txtCapacidade.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("Número ou capacidade inválidos. Use apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            status = Convert.ToString(lboStatus.SelectedItem);

            try
            {
                ClasseMesa mesa = new ClasseMesa(num, capacidade, status);
                admin.cadastrarMesa(mesa);
                MessageBox.Show("Mesa cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpar();
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmGerente gerente = new frmGerente(admin, idUsuario, cargo);
            gerente.Show();
            this.Close();
        }

        // btnEditar: carrega mesa para edição (preenche campos) — não salva
        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (txtPedido != null && !string.IsNullOrWhiteSpace(txtPedido.Text))
            {
                if (!int.TryParse(txtPedido.Text.Trim(), out int idPedido) || idPedido <= 0)
                {
                    MessageBox.Show("ID da mesa inválido. Use apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPedido.Focus();
                    return;
                }
                BuscarPreencherMesaPorId(idPedido);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtNum.Text))
            {
                if (!int.TryParse(txtNum.Text.Trim(), out int numero) || numero <= 0)
                {
                    MessageBox.Show("Número da mesa inválido. Use apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNum.Focus();
                    return;
                }
                BuscarPreencherMesaPorNumero(numero);
                return;
            }

            MessageBox.Show("Informe o ID (txtPedido) ou o Número (txtNum) da mesa para carregar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // SALVAR SIMPLES: usa o ID fornecido em txtPedido para fazer UPDATE direto no banco
            

        // Busca por idMesa
        private void BuscarPreencherMesaPorId(int id)
        {
            string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();
                    string query = "SELECT idMesa, numero, capacidade, status FROM mesa WHERE idMesa = @valor LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@valor", id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                                PreencherCamposMesaFromReader(reader);
                            else
                            {
                                MessageBox.Show("Mesa não encontrada para o ID informado.", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limpar();
                            }
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Erro ao consultar o banco:");
                sb.AppendLine(erro.Message);
                MessageBox.Show(sb.ToString());
            }
        }

        // Busca por numero
        private void BuscarPreencherMesaPorNumero(int numero)
        {
            string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";
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
                                PreencherCamposMesaFromReader(reader);
                            else
                            {
                                MessageBox.Show("Mesa não encontrada para o número informado.", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limpar();
                            }
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Erro ao consultar o banco:");
                sb.AppendLine(erro.Message);
                MessageBox.Show(sb.ToString());
            }
        }

        // Preenche os controles com os dados do reader
        private void PreencherCamposMesaFromReader(MySqlDataReader reader)
        {
            // preenche numero e capacidade
            txtNum.Text = reader.IsDBNull(reader.GetOrdinal("numero")) ? string.Empty : reader.GetInt32(reader.GetOrdinal("numero")).ToString();
            txtCapacidade.Text = reader.IsDBNull(reader.GetOrdinal("capacidade")) ? string.Empty : reader.GetInt32(reader.GetOrdinal("capacidade")).ToString();

            string status = reader.IsDBNull(reader.GetOrdinal("status")) ? string.Empty : reader.GetString(reader.GetOrdinal("status"));

            // seleciona no lboStatus item que case (ignorando case)
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
            if (!found) lboStatus.ClearSelected();

            // coloca idMesa no txtPedido (para referência)
            if (txtPedido != null)
                txtPedido.Text = reader.IsDBNull(reader.GetOrdinal("idMesa")) ? string.Empty : reader.GetInt32(reader.GetOrdinal("idMesa")).ToString();
        }

        private void TxtPedido_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPedido.Text)) return;
            if (!int.TryParse(txtPedido.Text.Trim(), out int id) || id <= 0)
            {
                MessageBox.Show("ID da mesa inválido. Use apenas números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPedido.Focus();
                return;
            }
            BuscarPreencherMesaPorId(id);
        }

        private void SetFieldsEditableMesa(bool editable)
        {
            // mantém campos editáveis para fluxo simples
            txtCapacidade.ReadOnly = !editable;
            lboStatus.Enabled = editable;
            txtNum.ReadOnly = !editable;

            txtCapacidade.BackColor = editable ? System.Drawing.SystemColors.Window : System.Drawing.SystemColors.Control;
            txtNum.BackColor = editable ? System.Drawing.SystemColors.Window : System.Drawing.SystemColors.Control;
        }

        // Atualiza a mesa no banco de dados (por idMesa)
        private bool UpdateMesaInDatabase(int idMesa, int numero, int capacidade, string status)
        {
            if (idMesa <= 0) return false;

            string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";
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
                        cmd.Parameters.AddWithValue("@idMesa", idMesa);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (MySqlException erro)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Erro Banco!");
                sb.AppendLine(erro.GetType().ToString());
                sb.AppendLine(erro.Message);
                MessageBox.Show(sb.ToString());
                return false;
            }
            catch (Exception erro)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Exceção Desconhecida !!!");
                sb.AppendLine(erro.GetType().ToString());
                sb.AppendLine(erro.Message);
                MessageBox.Show(sb.ToString());
                return false;
            }
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            if (txtPedido == null || string.IsNullOrWhiteSpace(txtPedido.Text))
            {
                MessageBox.Show("Informe o ID da mesa em 'ID Mesa' antes de salvar.", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPedido?.Focus();
                return;
            }

            if (!int.TryParse(txtPedido.Text.Trim(), out int idMesa) || idMesa <= 0)
            {
                MessageBox.Show("ID da mesa inválido. Use apenas números.", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPedido.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNum.Text) || string.IsNullOrWhiteSpace(txtCapacidade.Text) || lboStatus.SelectedItem == null)
            {
                MessageBox.Show("Preencha Número, Capacidade e Status antes de salvar.", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtNum.Text.Trim(), out int numero) || numero <= 0)
            {
                MessageBox.Show("Número da mesa inválido.", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNum.Focus();
                return;
            }

            if (!int.TryParse(txtCapacidade.Text.Trim(), out int capacidade) || capacidade < 0)
            {
                MessageBox.Show("Capacidade inválida.", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCapacidade.Focus();
                return;
            }

            string status = lboStatus.SelectedItem.ToString();

            // chama rotina de update
            if (UpdateMesaInDatabase(idMesa, numero, capacidade, status))
            {
                MessageBox.Show("Mesa atualizada com sucesso.", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpar();
            }
            else
            {
                MessageBox.Show("Falha ao atualizar a mesa. Verifique o ID.", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
   }
