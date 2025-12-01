using MySql.Data.MySqlClient;
using SupplyFlow;
using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace SupplyFlow
{
    public partial class frmEditarProduto : Form
    {
        private readonly string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";
        private bool modoEdicao = false;
        private int produtoCarregadoId = 0;

        public frmEditarProduto()
        {
            InitializeComponent();
            SetFieldsEditable(false);
            btnEditar.Text = "Editar";
        }

        // Ao clicar: primeiro carrega pelo ID; se já carregado, salva as alterações
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!modoEdicao)
            {
                // carregar pelo id inserido
                if (!int.TryParse(txtId.Text.Trim(), out int id) || id <= 0)
                {
                    MessageBox.Show("Informe um ID de produto válido (número inteiro).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtId.Focus();
                    return;
                }

                if (CarregarProdutoPorId(id))
                {
                    modoEdicao = true;
                    btnEditar.Text = "Salvar";
                    SetFieldsEditable(true);
                    txtNome.Focus();
                }
                else
                {
                    MessageBox.Show("Produto não encontrado com o ID informado.", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return;
            }

            // salvar alterações
            if (produtoCarregadoId == 0)
            {
                MessageBox.Show("Nenhum produto carregado para salvar.", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCamposAntesSalvar(out string nome, out string categoria, out int qtd, out int qtdIdeal, out string uniMed, out double preco))
                return;

            if (AtualizarProdutoNoBanco(produtoCarregadoId, nome, categoria, qtd, qtdIdeal, uniMed, preco))
            {
                MessageBox.Show("Produto atualizado com sucesso.", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                modoEdicao = false;
                produtoCarregadoId = 0;
                btnEditar.Text = "Editar";
                SetFieldsEditable(false);
                ClearFields();
            }
            else
            {
                MessageBox.Show("Falha ao atualizar produto. Verifique o ID e tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carrega produto por idProduto; retorna true se encontrado e preenchido
        private bool CarregarProdutoPorId(int idProduto)
        {
            try
            {
                using (var conn = new MySqlConnection(conexao))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"
                        SELECT idProduto,
                               `descrição`    AS descricao,
                               categoria,
                               quantidade_atual    AS quantidade_atual,
                               quantidade_adequada AS quantidade_adequada,
                               unidade_medida,
                               `preço_compra`      AS preco
                        FROM produto
                        WHERE idProduto = @id
                        LIMIT 1";
                    cmd.Parameters.AddWithValue("@id", idProduto);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return false;

                        produtoCarregadoId = reader.IsDBNull(reader.GetOrdinal("idProduto")) ? 0 : reader.GetInt32(reader.GetOrdinal("idProduto"));
                        txtId.Text = produtoCarregadoId == 0 ? string.Empty : produtoCarregadoId.ToString();
                        txtNome.Text = reader.IsDBNull(reader.GetOrdinal("descricao")) ? string.Empty : reader.GetString(reader.GetOrdinal("descricao"));
                        txtCategoria.Text = reader.IsDBNull(reader.GetOrdinal("categoria")) ? string.Empty : reader.GetString(reader.GetOrdinal("categoria"));
                        txtQtd.Text = reader.IsDBNull(reader.GetOrdinal("quantidade_atual")) ? string.Empty : reader.GetInt32(reader.GetOrdinal("quantidade_atual")).ToString();
                        txtQtdIdeal.Text = reader.IsDBNull(reader.GetOrdinal("quantidade_adequada")) ? string.Empty : reader.GetInt32(reader.GetOrdinal("quantidade_adequada")).ToString();
                        txtUniMed.Text = reader.IsDBNull(reader.GetOrdinal("unidade_medida")) ? string.Empty : reader.GetString(reader.GetOrdinal("unidade_medida"));
                        if (!reader.IsDBNull(reader.GetOrdinal("preco")))
                        {
                            var valor = reader.GetDouble(reader.GetOrdinal("preco"));
                            mtxtPreco.Text = valor.ToString("F2", CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            mtxtPreco.Text = string.Empty;
                        }

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Erro ao consultar o banco:");
                sb.AppendLine(ex.Message);
                MessageBox.Show(sb.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Valida campos do formulário e converte para tipos corretos
        private bool ValidarCamposAntesSalvar(out string nome, out string categoria, out int qtd, out int qtdIdeal, out string uniMed, out double preco)
        {
            nome = txtNome.Text.Trim();
            categoria = txtCategoria.Text.Trim();
            uniMed = txtUniMed.Text.Trim();
            qtd = 0;
            qtdIdeal = 0;
            preco = 0;

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Nome não pode ficar vazio.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            if (!int.TryParse(txtQtd.Text.Trim(), out qtd))
            {
                MessageBox.Show("Quantidade inválida.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtd.Focus();
                return false;
            }

            if (!int.TryParse(txtQtdIdeal.Text.Trim(), out qtdIdeal))
            {
                MessageBox.Show("Quantidade ideal inválida.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtdIdeal.Focus();
                return false;
            }

            string precoRaw = (mtxtPreco.Text ?? string.Empty).Trim();
            precoRaw = precoRaw.Replace("R$", "").Replace("$", "").Replace(" ", "").Replace(",", ".");
            if (!double.TryParse(precoRaw, NumberStyles.Any, CultureInfo.InvariantCulture, out preco))
            {
                MessageBox.Show("Preço inválido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtPreco.Focus();
                return false;
            }

            return true;
        }

        // Executa UPDATE no banco; retorna true se pelo menos uma linha afetada
        private bool AtualizarProdutoNoBanco(int idProduto, string nome, string categoria, int qtd, int qtdIdeal, string uniMed, double preco)
        {
            try
            {
                using (var conn = new MySqlConnection(conexao))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"
                        UPDATE produto
                        SET `descrição` = @nome,
                            categoria = @categoria,
                            quantidade_atual = @qtd,
                            quantidade_adequada = @qtdIdeal,
                            unidade_medida = @uniMed,
                            `preço_compra` = @preco
                        WHERE idProduto = @idProduto";
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    cmd.Parameters.AddWithValue("@qtd", qtd);
                    cmd.Parameters.AddWithValue("@qtdIdeal", qtdIdeal);
                    cmd.Parameters.AddWithValue("@uniMed", uniMed);
                    cmd.Parameters.AddWithValue("@preco", preco);
                    cmd.Parameters.AddWithValue("@idProduto", idProduto);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Erro ao atualizar o banco:");
                sb.AppendLine(ex.Message);
                MessageBox.Show(sb.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Helper para manter nomes curtos
        private bool UpdateProdutoInDatabase(int idProduto, string nome, string categoria, int qtd, int qtdIdeal, string uniMed, double preco)
        {
            return AtualizarProdutoNoBanco(idProduto, nome, categoria, qtd, qtdIdeal, uniMed, preco);
        }

        private void ClearFields()
        {
            txtId.Clear();
            txtNome.Clear();
            txtCategoria.Clear();
            txtQtd.Clear();
            txtQtdIdeal.Clear();
            txtUniMed.Clear();
            mtxtPreco.Clear();
        }

        private void SetFieldsEditable(bool editable)
        {
            txtNome.ReadOnly = !editable;
            txtCategoria.ReadOnly = !editable;
            txtQtd.ReadOnly = !editable;
            txtQtdIdeal.ReadOnly = !editable;
            txtUniMed.ReadOnly = !editable;
            mtxtPreco.ReadOnly = !editable;

            txtNome.BackColor = editable ? System.Drawing.SystemColors.Window : System.Drawing.SystemColors.Control;
            txtCategoria.BackColor = editable ? System.Drawing.SystemColors.Window : System.Drawing.SystemColors.Control;
            txtQtd.BackColor = editable ? System.Drawing.SystemColors.Window : System.Drawing.SystemColors.Control;
            txtQtdIdeal.BackColor = editable ? System.Drawing.SystemColors.Window : System.Drawing.SystemColors.Control;
            txtUniMed.BackColor = editable ? System.Drawing.SystemColors.Window : System.Drawing.SystemColors.Control;
            mtxtPreco.BackColor = editable ? System.Drawing.SystemColors.Window : System.Drawing.SystemColors.Control;
        }

        // ao mudar o ID manualmente zera estado de edição
        private void txtId_TextChanged(object sender, EventArgs e)
        {
            produtoCarregadoId = 0;
            modoEdicao = false;
            btnEditar.Text = "Editar";
            SetFieldsEditable(false);
        }
    }
}