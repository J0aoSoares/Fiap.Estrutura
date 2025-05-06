using System;
using Oracle.ManagedDataAccess.Client;

namespace Fiap.Estrutura.DAL
{
    public class ConexaoOracle
    {
        private static readonly string StringConexao =
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SID=ORCL)));User Id=rm551410;Password=220205;";

        public static OracleConnection ObterConexao()
        {
            return new OracleConnection(StringConexao);
        }
    }
}
