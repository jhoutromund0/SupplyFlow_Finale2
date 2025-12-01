using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using static SupplyFlow.frmCadInsumo;

namespace SupplyFlow
{
    public class Admin
    {
        private readonly string connectionStr;

        public Admin()
        {
            connectionStr = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";
        }

        public void cadastrarFunc(ClasseFuncionario funcionario)
        {
            try
            {
                using (var connectionBD = new MySqlConnection(connectionStr))
                using (var commBD = connectionBD.CreateCommand())
                {
                    connectionBD.Open();
                    commBD.CommandText = @"INSERT INTO funcionario (nome, login, senha, cargo, salario, data_admissao, telefone, cpf) 
                                           VALUES (@nome, @login, @senha, @cargo, @salario, @data_admissao, @telefone, @cpf)";
                    commBD.Parameters.AddWithValue("@nome", funcionario.getNome());
                    commBD.Parameters.AddWithValue("@login", funcionario.getLogin());
                    commBD.Parameters.AddWithValue("@senha", funcionario.getSenha());
                    commBD.Parameters.AddWithValue("@cargo", funcionario.getCargo());
                    commBD.Parameters.AddWithValue("@salario", funcionario.getSalario());
                    commBD.Parameters.AddWithValue("@data_admissao", funcionario.getDataAdm());
                    commBD.Parameters.AddWithValue("@telefone", funcionario.getTelefone());
                    commBD.Parameters.AddWithValue("@cpf", funcionario.getCpf());

                    commBD.ExecuteNonQuery();
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

        public void cadastrarProduto(ClasseProduto produto)
        {
            try
            {
                using (var connectionBD = new MySqlConnection(connectionStr))
                using (var commBD = connectionBD.CreateCommand())
                {
                    connectionBD.Open();
                    commBD.CommandText = @"INSERT INTO produto (descrição, categoria, quantidade_atual, quantidade_adequada, unidade_medida, preço_compra) 
                                           VALUES (@descricao, @categoria, @quantidade_atual, @quantidade_adequada, @unidade_medida, @preco_compra)";
                    commBD.Parameters.AddWithValue("@descricao", produto.getDesc());
                    commBD.Parameters.AddWithValue("@categoria", produto.getCategoria());
                    commBD.Parameters.AddWithValue("@quantidade_atual", produto.getQuantAtual());
                    commBD.Parameters.AddWithValue("@quantidade_adequada", produto.getQuantIdeal());
                    commBD.Parameters.AddWithValue("@unidade_medida", produto.getUniMed());
                    commBD.Parameters.AddWithValue("@preco_compra", produto.getPreco());

                    commBD.ExecuteNonQuery();
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

        public void cadastrarCardapio(ClasseCardapio cardapio)
        {
            try
            {
                using (var connectionBD = new MySqlConnection(connectionStr))
                using (var commBD = connectionBD.CreateCommand())
                {
                    connectionBD.Open();
                    commBD.CommandText = @"INSERT INTO cardapio (nome, descrição, preço, categoria) 
                                           VALUES (@nome, @descricao, @preco, @categoria)";
                    commBD.Parameters.AddWithValue("@nome", cardapio.getNome());
                    commBD.Parameters.AddWithValue("@descricao", cardapio.getDesc());
                    commBD.Parameters.AddWithValue("@preco", cardapio.getPreco());
                    commBD.Parameters.AddWithValue("@categoria", cardapio.getCategoria());

                    commBD.ExecuteNonQuery();
                }
            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Erro Banco! " + erro.Message);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Exceção Desconhecida !!! " + erro.Message);
            }
        }

        public void cadastrarMesa(ClasseMesa mesa)
        {
            try
            {
                using (var connectionBD = new MySqlConnection(connectionStr))
                using (var commBD = connectionBD.CreateCommand())
                {
                    connectionBD.Open();
                    commBD.CommandText = @"INSERT INTO mesa (numero, capacidade, status) VALUES (@numero, @capacidade, @status)";
                    commBD.Parameters.AddWithValue("@numero", mesa.getNum());
                    commBD.Parameters.AddWithValue("@capacidade", mesa.getCapacidade());
                    commBD.Parameters.AddWithValue("@status", mesa.getStatus());

                    commBD.ExecuteNonQuery();
                }
            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Erro Banco! " + erro.Message);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Exceção Desconhecida !!! " + erro.Message);
            }
        }

        public void cadastrarInsumo(ClasseInsumo insumo)
        {
            try
            {
                using (var connectionBD = new MySqlConnection(connectionStr))
                using (var commBD = connectionBD.CreateCommand())
                {
                    connectionBD.Open();
                    commBD.CommandText = @"INSERT INTO insumos (quantidade_produto, idProduto, idPrato) VALUES (@quantidade_produto, @idProduto, @idPrato)";
                    commBD.Parameters.AddWithValue("@quantidade_produto", insumo.getQtd());
                    commBD.Parameters.AddWithValue("@idProduto", insumo.getIdProd());
                    commBD.Parameters.AddWithValue("@idPrato", insumo.getIdCardapio());

                    commBD.ExecuteNonQuery();
                }
            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Erro Banco! " + erro.Message);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Exceção Desconhecida !!! " + erro.Message);
            }
        }

        public void cadastrarPagamento(ClassePagamento pagamento)
        {
            try
            {
                using (var connectionBD = new MySqlConnection(connectionStr))
                using (var commBD = connectionBD.CreateCommand())
                {
                    connectionBD.Open();
                    commBD.CommandText = @"INSERT INTO pagamento (tipo_pagamento, data_hora, valor, statusPg, idVenda) 
                                           VALUES (@tipo_pagamento, @data_hora, @valor, @statusPg, @idVenda)";
                    commBD.Parameters.AddWithValue("@tipo_pagamento", pagamento.getTipo());
                    commBD.Parameters.AddWithValue("@data_hora", pagamento.getDataHora());
                    commBD.Parameters.AddWithValue("@valor", pagamento.getValor());
                    commBD.Parameters.AddWithValue("@statusPg", pagamento.getStatus());
                    commBD.Parameters.AddWithValue("@idVenda", pagamento.getIdVenda());

                    commBD.ExecuteNonQuery();
                }
            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Erro Banco! " + erro.Message);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Exceção Desconhecida !!! " + erro.Message);
            }
        }

        public void cadastrarVenda(ClasseVenda venda)
        {
            try
            {
                using (var connectionBD = new MySqlConnection(connectionStr))
                using (var commBD = connectionBD.CreateCommand())
                {
                    connectionBD.Open();
                    commBD.CommandText = @"INSERT INTO venda (data_venda, hora_venda, idUsuario, idMesa) 
                                           VALUES (@data_venda, @hora_venda, @idUsuario, @idMesa)";
                    commBD.Parameters.AddWithValue("@data_venda", venda.getData());
                    commBD.Parameters.AddWithValue("@hora_venda", venda.getHora());
                    commBD.Parameters.AddWithValue("@idUsuario", venda.getIdUsuario());
                    commBD.Parameters.AddWithValue("@idMesa", venda.getIdMesa());

                    commBD.ExecuteNonQuery();
                }
            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Erro Banco! " + erro.Message);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Exceção Desconhecida !!! " + erro.Message);
            }
        }

        // Produtos - Relatórios
        public DataTable RelatorioNome(string nome)
        {
            var dt = new DataTable();
            try
            {
                using (var conn = new MySqlConnection(connectionStr))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"SELECT descrição AS Descricao, categoria, quantidade_atual AS QuantidadeAtual, quantidade_adequada AS QuantidadeAdequada, unidade_medida AS UnidadeMedida, preço_compra AS PrecoCompra
                                        FROM produto
                                        WHERE descrição LIKE @nome";
                    cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório: " + ex.Message);
            }
            return dt;
        }

        public DataTable RelatoriaGeral()
        {
            var dt = new DataTable();
            try
            {
                using (var conn = new MySqlConnection(connectionStr))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"SELECT descrição AS Descricao, categoria, quantidade_atual AS QuantidadeAtual, quantidade_adequada AS QuantidadeAdequada, unidade_medida AS UnidadeMedida, preço_compra AS PrecoCompra
                                        FROM produto";
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório: " + ex.Message);
            }
            return dt;
        }

        public DataTable RelatorioCategoria(string categoria)
        {
            var dt = new DataTable();
            try
            {
                using (var conn = new MySqlConnection(connectionStr))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"SELECT descrição AS Descricao, categoria, quantidade_atual AS QuantidadeAtual, quantidade_adequada AS QuantidadeAdequada, unidade_medida AS UnidadeMedida, preço_compra AS PrecoCompra
                                        FROM produto
                                        WHERE categoria LIKE @categoria";
                    cmd.Parameters.AddWithValue("@categoria", "%" + categoria + "%");
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório: " + ex.Message);
            }
            return dt;
        }

        public DataTable GetProdutoById(int id)
        {
            var dt = new DataTable();
            try
            {
                using (var conn = new MySqlConnection(connectionStr))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"SELECT id, descrição AS Descricao, categoria, quantidade_atual AS QuantidadeAtual, quantidade_adequada AS QuantidadeAdequada, unidade_medida AS UnidadeMedida, preço_compra AS PrecoCompra
                                        FROM produto
                                        WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar produto por ID: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public bool DeleteProdutoById(int id)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionStr))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "DELETE FROM produto WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateProdutoById(int id, string descricao, string categoria, int quantidadeAtual, int quantidadeAdequada, string unidadeMedida, double precoCompra)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionStr))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"UPDATE produto
                                        SET descrição = @descricao,
                                            categoria = @categoria,
                                            quantidade_atual = @quantidadeAtual,
                                            quantidade_adequada = @quantidadeAdequada,
                                            unidade_medida = @unidadeMedida,
                                            preço_compra = @precoCompra
                                        WHERE id = @id";
                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    cmd.Parameters.AddWithValue("@quantidadeAtual", quantidadeAtual);
                    cmd.Parameters.AddWithValue("@quantidadeAdequada", quantidadeAdequada);
                    cmd.Parameters.AddWithValue("@unidadeMedida", unidadeMedida);
                    cmd.Parameters.AddWithValue("@precoCompra", precoCompra);
                    cmd.Parameters.AddWithValue("@id", id);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Vendas - Relatórios
        public DataTable RelatoriaGeralV()
        {
            var dt = new DataTable();
            try
            {
                using (var conn = new MySqlConnection(connectionStr))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"
                        SELECT 
                            v.idVenda AS IdVenda,
                            v.data_venda AS DataVenda,
                            v.hora_venda AS HoraVenda,
                            v.idUsuario AS IdUsuario,
                            v.idMesa AS IdMesa,
                            p.tipo_pagamento AS TipoPagamento,
                            p.valor AS ValorPagamento,
                            p.statusPg AS StatusPagamento
                        FROM venda v
                        LEFT JOIN pagamento p ON p.idVenda = v.idVenda
                        ORDER BY v.data_venda DESC, v.hora_venda DESC";
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório de vendas: " + ex.Message);
            }
            return dt;
        }

        public DataTable RelatorioPorData(DateTime data)
        {
            var dt = new DataTable();
            try
            {
                using (var conn = new MySqlConnection(connectionStr))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"
                        SELECT 
                            v.idVenda AS IdVenda,
                            v.data_venda AS DataVenda,
                            v.hora_venda AS HoraVenda,
                            v.idUsuario AS IdUsuario,
                            v.idMesa AS IdMesa,
                            p.tipo_pagamento AS TipoPagamento,
                            p.valor AS ValorPagamento,
                            p.statusPg AS StatusPagamento
                        FROM venda v
                        LEFT JOIN pagamento p ON p.idVenda = v.idVenda
                        WHERE DATE(v.data_venda) = @data
                        ORDER BY v.hora_venda";
                    // passar data no formato yyyy-MM-dd para compatibilidade com DATE()
                    cmd.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd"));
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório por data: " + ex.Message);
            }
            return dt;
        }

        public DataTable RelatorioGarcom(string garcom)
        {
            var dt = new DataTable();
            try
            {
                using (var conn = new MySqlConnection(connectionStr))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"
                        SELECT 
                            v.idVenda AS IdVenda,
                            v.data_venda AS DataVenda,
                            v.hora_venda AS HoraVenda,
                            v.idMesa AS IdMesa,
                            f.nome AS Garcom
                        FROM venda v
                        INNER JOIN funcionario f ON v.idUsuario = f.idUsuario
                        WHERE f.nome LIKE @garcom
                        ORDER BY v.data_venda DESC, v.hora_venda DESC";
                    cmd.Parameters.AddWithValue("@garcom", "%" + garcom + "%");
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório do Garçom: " + ex.Message);
            }
            return dt;
        }

        public void cadastrarItemVenda(ClasseItemVenda itemVenda)
        {
            try
            {
                using (var connectionBD = new MySqlConnection(connectionStr))
                using (var commBD = connectionBD.CreateCommand())
                {
                    connectionBD.Open();
                    commBD.CommandText = @"INSERT INTO Itens_Venda (quantidade, idVenda, idPrato) 
                                   VALUES (@quantidade, @idVenda, @idPrato)";
                    commBD.Parameters.AddWithValue("@quantidade", itemVenda.getQuantidade());
                    commBD.Parameters.AddWithValue("@idVenda", itemVenda.getIdVenda());
                    commBD.Parameters.AddWithValue("@idPrato", itemVenda.getIdPrato());

                    commBD.ExecuteNonQuery();
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

        //EDIÇÕES
        public void editarCardapio(ClasseCardapio cardapio, int id)
        {
            try
            {

                string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";

                using (var connection = new MySqlConnection(conexao))
                {
                    connection.Open();

                    string sql = @"UPDATE cardapio 
                       SET nome = @nome,
                           descrição = @descricao,
                           preço = @preco,
                           categoria = @categoria
                       WHERE idPrato = @id";

                    using (var cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@nome", cardapio.getNome());
                        cmd.Parameters.AddWithValue("@descricao", cardapio.getDesc());
                        cmd.Parameters.AddWithValue("@preco", cardapio.getPreco());
                        cmd.Parameters.AddWithValue("@categoria", cardapio.getCategoria());
                        cmd.Parameters.AddWithValue("@id", id);

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas == 0)
                        {
                            MessageBox.Show("Nenhum registro foi alterado. ID não encontrado.");
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

        public void editarInsumo(ClasseInsumo insumo, int id)
        {
            try
            {
                string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";

                using (var connection = new MySqlConnection(conexao))
                {
                    connection.Open();

                    string sql = @"UPDATE Insumos
                       SET quantidade_produto = @quantidade_produto,
                           idProduto = @idProduto,
                           idPrato = @idPrato
                       WHERE idInsumo = @id";

                    using (var cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@quantidade_produto", insumo.getQtd());
                        cmd.Parameters.AddWithValue("@idProduto", insumo.getIdProd());
                        cmd.Parameters.AddWithValue("@idPrato", insumo.getIdCardapio());
                        cmd.Parameters.AddWithValue("@id", id);

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas == 0)
                        {
                            MessageBox.Show("Nenhum registro foi alterado. ID não encontrado.");
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

        public void editarItemvenda(ClasseItemVenda itemVenda, int id)
        {
            try
            {
                string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";

                using (var connection = new MySqlConnection(conexao))
                {
                    connection.Open();

                    string sql = @"UPDATE itens_venda
                       SET quantidade = @quantidade,
                           idVenda = @idVenda,
                           idPrato = @idPrato
                       WHERE idItensVenda = @id";

                    using (var cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@quantidade", itemVenda.getQuantidade());
                        cmd.Parameters.AddWithValue("@idVenda", itemVenda.getIdVenda());
                        cmd.Parameters.AddWithValue("@idPrato", itemVenda.getIdPrato());
                        cmd.Parameters.AddWithValue("@id", id);

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas == 0)
                        {
                            MessageBox.Show("Nenhum registro foi alterado. ID não encontrado.");
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
        public void editarFuncionario(ClasseFuncionario funcionario, int id)
        {
            try
            {
                string conexao = @"server=127.0.0.1;uid=root;pwd=1234;database=supplyflow;ConnectionTimeout=1";

                using (var connection = new MySqlConnection(conexao))
                {
                    connection.Open();

                    string sql = @"UPDATE funcionario
                       SET nome = @nome,
                            login = @login,
                            senha = @senha,
                            cargo = @cargo,
                            salario = @salario,
                            data_admissao = @data_admissao,
                            telefone = @telefone,
                            cpf = @cpf
                       WHERE idUsuario = @id";

                    using (var cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@nome", funcionario.getNome());
                        cmd.Parameters.AddWithValue("@login", funcionario.getLogin());
                        cmd.Parameters.AddWithValue("@senha", funcionario.getSenha());
                        cmd.Parameters.AddWithValue("@cargo", funcionario.getCargo());
                        cmd.Parameters.AddWithValue("@salario", funcionario.getSalario());
                        cmd.Parameters.AddWithValue("@data_admissao", funcionario.getDataAdm());
                        cmd.Parameters.AddWithValue("@telefone", funcionario.getTelefone());
                        cmd.Parameters.AddWithValue("@cpf", funcionario.getCpf());
                        cmd.Parameters.AddWithValue("@id", id);

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas == 0)
                        {
                            MessageBox.Show("Nenhum registro foi alterado. ID não encontrado.");
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