using System;
using System.Collections.Generic;
using Fiap.Estrutura.BLL;
using Fiap.Estrutura.Model;

namespace Fiap.Estrutura.UI
{
    class Program
    {
        private static readonly LoginService _loginService = new LoginService();
        private static readonly FuncionarioService _funcionarioService = new FuncionarioService();
        private static readonly ProdutoService _produtoService = new ProdutoService();

        static void Main(string[] args)
        {
            try
            {
                RealizarLogin();
                ExibirMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na aplicação: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nPressione qualquer tecla para encerrar...");
                Console.ReadKey();
            }
        }

        private static void RealizarLogin()
        {
            bool loginValido = false;
            string usuario = string.Empty;

            while (!loginValido)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTÃO - LOGIN ===");
                Console.WriteLine();

                Console.Write("Usuário: ");
                usuario = Console.ReadLine();

                Console.Write("Senha: ");
                string senha = LerSenha();

                try
                {
                    // Validar credenciais
                    if (!_loginService.ValidarCredenciais(usuario, senha))
                    {
                        Console.WriteLine("\nErro: Usuário ou senha inválidos.");
                        Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                        continue;
                    }

                    // Validar segurança da senha
                    if (!_loginService.ValidarSenhaSegura(senha))
                    {
                        Console.WriteLine("\nAlerta: A senha não contém caracteres especiais.");
                    }

                    // Validar data de sessão
                    Console.Write("\nInforme a data atual (dd/MM/yyyy): ");
                    string dataString = Console.ReadLine();

                    if (!_loginService.ValidarDataSessao(dataString))
                    {
                        Console.WriteLine("Erro: Data inválida ou diferente da data atual.");
                        Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                        continue;
                    }

                    loginValido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nErro: {ex.Message}");
                    Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                }
            }

            // Obter informações do usuário e exibir mensagem de boas-vindas
            string nomeCompleto = _loginService.ObterNomeCompleto(usuario);
            string ra = _loginService.ObterRA(usuario);

            Console.Clear();
            Console.WriteLine($"Bem-vindo(a), {nomeCompleto} [RA: {ra}]!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private static string LerSenha()
        {
            string senha = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    senha += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && senha.Length > 0)
                {
                    senha = senha.Substring(0, senha.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return senha;
        }

        private static void ExibirMenu()
        {
            bool sair = false;

            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("=== MENU PRINCIPAL ===");
                Console.WriteLine("1. Listar Funcionários e Dados Adicionais");
                Console.WriteLine("2. Listar Produtos e Dados Adicionais");
                Console.WriteLine("3. Sair");
                Console.WriteLine("======================");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ListarFuncionarios();
                        break;
                    case "2":
                        ListarProdutos();
                        break;
                    case "3":
                        sair = true;
                        Console.WriteLine("Encerrando a aplicação...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ListarFuncionarios()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== LISTA DE FUNCIONÁRIOS ===");
                Console.WriteLine();

                List<Funcionario> funcionarios = _funcionarioService.ObterTodosFuncionarios();

                foreach (var funcionario in funcionarios)
                {
                    Console.WriteLine(funcionario.ToString());
                }

                Console.WriteLine();
                Console.WriteLine($"Total de Funcionários: {_funcionarioService.ObterTotalFuncionarios()}");
                Console.WriteLine($"Maior Salário: {_funcionarioService.ObterMaiorSalario():C}");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar funcionários: {ex.Message}");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }
        }

        private static void ListarProdutos()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== LISTA DE PRODUTOS ===");
                Console.WriteLine();

                List<Produto> produtos = _produtoService.ObterTodosProdutos();

                foreach (var produto in produtos)
                {
                    Console.WriteLine(produto.ToString());
                }

                Console.WriteLine();
                Console.WriteLine($"Total de Produtos: {_produtoService.ObterTotalProdutos()}");
                Console.WriteLine($"Preço Médio: {_produtoService.ObterPrecoMedio():C}");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar produtos: {ex.Message}");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }
        }
    }
}
