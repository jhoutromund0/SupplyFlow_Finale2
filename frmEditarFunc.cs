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
using static SupplyFlow.frmEditarInsumo;

namespace SupplyFlow
{
    public partial class frmEditarFunc : Form
    {
        private Admin admin;
        private int idUsuario;
        private string cargo;
        private int id;
        public frmEditarFunc(Admin admin, int idUsuairo, string cargo)
        {
            InitializeComponent();
            this.admin = admin;
            this.idUsuario = idUsuairo;
            this.cargo = cargo;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        public void Limpar()
        {
            txtCPF.Clear();
            txtDataAdm.Clear();
            txtId.Clear();
            txtLogin.Clear();
            txtNome.Clear();
            txtSalario.Clear();
            txtSenha.Clear();
            txtTelefone.Clear();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmGerente gerente = new frmGerente(admin, idUsuario, cargo);
            gerente.Show();
            this.Close();
        }

        private void btnId_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("ID não preenchido! Tente novamente preenchendo-o: ");
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

                        string sql = "SELECT nome, login, senha, cargo, salario, data_admissao, telefone, cpf from funcionario WHERE idUsuario = @id";

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
                                    txtLogin.Text = reader.GetString("login");
                                    txtSenha.Text = reader.GetString("senha");
                                    txtSenha.UseSystemPasswordChar = false;
                                    lboCargo.SelectedItem = reader.GetString("cargo").ToLower();
                                    txtSalario.Text = Convert.ToString(reader.GetDouble("salario"));
                                    txtDataAdm.Text = reader.GetDateTime("data_admissao").ToString();
                                    txtTelefone.Text = reader.GetString("telefone");
                                    txtCPF.Text = reader.GetString("cpf");

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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtCPF.Text == "" || txtDataAdm.Text == "" || txtId.Text == "" || txtLogin.Text == "" || txtNome.Text == "" || txtSalario.Text == "" || txtSenha.Text == "" || txtTelefone.Text == "" || lboCargo.SelectedItem == null)
            {
                MessageBox.Show("Campos vazios! Preencha-os para editar o produto!");
                return;
            }
            else
            {
                string nome, login, senha, cargo, telefone, cpf;
                double salario;
                DateTime data_adm;

                nome = txtNome.Text;
                login = txtLogin.Text;
                senha = txtSenha.Text;
                cargo = lboCargo.SelectedItem.ToString();
                telefone = txtTelefone.Text;
                cpf = txtCPF.Text;
                try
                {
                    salario = Convert.ToDouble(txtSalario.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Salário preenchido com caracteres! Retire-os e tente novamente:");
                    return;
                }
                try
                {
                    data_adm = Convert.ToDateTime(txtDataAdm.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Data Incopatível! Preencha novamente:");
                    return;
                }
                try
                {
                    ClasseFuncionario funcionario = new ClasseFuncionario(nome, cargo, cpf, login, senha, telefone, salario, data_adm);
                    admin.editarFuncionario(funcionario, id);
                    MessageBox.Show("Funcionário atualizado com sucesso!");
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
    }
}
