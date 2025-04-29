using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Fiap.Estrutura.DAL
{
    public class ConexaoOracle
    {
        // Altere a string de conexão conforme seu ambiente
        private static readonly string StringConexao = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));User Id=seu_usuario;Password=sua_senha;";

        public static OracleConnection ObterConexao()
        {
            try
            {
                OracleConnection conexao = new OracleConnection(StringConexao);
                return conexao;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conectar com Oracle: " + ex.Message);
            }
        }
    }
}
