using System;
using System.Collections.Generic;
using Fiap.Estrutura.Model;
using Oracle.ManagedDataAccess.Client;

namespace Fiap.Estrutura.DAL
{
    public class FuncionarioDAL
    {
        public List<Funcionario> ListarTodos()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            try
            {
                using (OracleConnection conexao = ConexaoOracle.ObterConexao())
                {
                    conexao.Open();

                    OracleCommand cmd = conexao.CreateCommand();
                    cmd.CommandText = "SELECT * FROM TBL_FUNCIONARIOS";

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Funcionario funcionario = new Funcionario
                            {
                                Id = Convert.ToInt32(reader["ID_FUNCIONARIO"]),
                                Nome = reader["NM_FUNCIONARIO"].ToString(),
                                Salario = Convert.ToDecimal(reader["VL_SALARIO"])
                            };

                            funcionarios.Add(funcionario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar funcionários: " + ex.Message);
            }

            return funcionarios;
        }

        public bool ValidarCredenciais(string usuario, string senha)
        {
            try
            {
                using (OracleConnection conexao = ConexaoOracle.ObterConexao())
                {
                    conexao.Open();

                    OracleCommand cmd = conexao.CreateCommand();
                    cmd.CommandText = "SELECT COUNT(*) FROM TBL_USUARIOS WHERE NM_USUARIO = :usuario AND DS_SENHA = :senha";
                    cmd.Parameters.Add(":usuario", OracleDbType.Varchar2).Value = usuario;
                    cmd.Parameters.Add(":senha", OracleDbType.Varchar2).Value = senha;

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao validar credenciais: " + ex.Message);
            }
        }

        public string ObterNomeUsuario(string usuario)
        {
            try
            {
                using (OracleConnection conexao = ConexaoOracle.ObterConexao())
                {
                    conexao.Open();

                    OracleCommand cmd = conexao.CreateCommand();
                    cmd.CommandText = "SELECT NM_COMPLETO FROM TBL_USUARIOS WHERE NM_USUARIO = :usuario";
                    cmd.Parameters.Add(":usuario", OracleDbType.Varchar2).Value = usuario;

                    object result = cmd.ExecuteScalar();

                    return result != null ? result.ToString() : string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter nome do usuário: " + ex.Message);
            }
        }

        public string ObterRAUsuario(string usuario)
        {
            try
            {
                using (OracleConnection conexao = ConexaoOracle.ObterConexao())
                {
                    conexao.Open();

                    OracleCommand cmd = conexao.CreateCommand();
                    cmd.CommandText = "SELECT NR_RA FROM TBL_USUARIOS WHERE NM_USUARIO = :usuario";
                    cmd.Parameters.Add(":usuario", OracleDbType.Varchar2).Value = usuario;

                    object result = cmd.ExecuteScalar();

                    return result != null ? result.ToString() : string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter RA do usuário: " + ex.Message);
            }
        }
    }
}
