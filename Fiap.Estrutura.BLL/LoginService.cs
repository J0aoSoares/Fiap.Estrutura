using System;
using System.Text.RegularExpressions;
using Fiap.Estrutura.DAL;

namespace Fiap.Estrutura.BLL
{
    public class LoginService
    {
        private readonly FuncionarioDAL _funcionarioDAL;

        public LoginService()
        {
            _funcionarioDAL = new FuncionarioDAL();
        }

        public bool ValidarCredenciais(string usuario, string senha)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                throw new Exception("Usuário e senha são obrigatórios!");
            }

            return _funcionarioDAL.ValidarCredenciais(usuario, senha);
        }

        public bool ValidarSenhaSegura(string senha)
        {
            if (string.IsNullOrEmpty(senha))
            {
                return false;
            }

            // Verifica se a senha possui algum caractere especial
            Regex regex = new Regex(@"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]");
            return regex.IsMatch(senha);
        }

        public bool ValidarDataSessao(string dataString)
        {
            if (string.IsNullOrEmpty(dataString))
            {
                return false;
            }

            // Tenta converter a string para data no formato dd/MM/yyyy
            if (!DateTime.TryParseExact(dataString, "dd/MM/yyyy", null,
                System.Globalization.DateTimeStyles.None, out DateTime data))
            {
                return false;
            }

            // Compara com a data atual
            DateTime hoje = DateTime.Today;
            return data.Date == hoje.Date;
        }

        public string ObterNomeCompleto(string usuario)
        {
            return _funcionarioDAL.ObterNomeUsuario(usuario);
        }

        public string ObterRA(string usuario)
        {
            return _funcionarioDAL.ObterRAUsuario(usuario);
        }
    }
}
