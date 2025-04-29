using System;
using System.Collections.Generic;
using Fiap.Estrutura.Model;
using Oracle.ManagedDataAccess.Client;

namespace Fiap.Estrutura.DAL
{
    public class ProdutoDAL
    {
        public List<Produto> ListarTodos()
        {
            List<Produto> produtos = new List<Produto>();

            try
            {
                using (OracleConnection conexao = ConexaoOracle.ObterConexao())
                {
                    conexao.Open();

                    OracleCommand cmd = conexao.CreateCommand();
                    cmd.CommandText = "SELECT * FROM TBL_PRODUTOS";

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto produto = new Produto
                            {
                                Id = Convert.ToInt32(reader["ID_PRODUTO"]),
                                Nome = reader["NM_PRODUTO"].ToString(),
                                Preco = Convert.ToDecimal(reader["VL_PRECO"])
                            };

                            produtos.Add(produto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar produtos: " + ex.Message);
            }

            return produtos;
        }
    }
}
