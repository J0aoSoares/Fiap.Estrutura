using System;
using System.Collections.Generic;
using System.Linq;
using Fiap.Estrutura.DAL;
using Fiap.Estrutura.Model;

namespace Fiap.Estrutura.BLL
{
    public class FuncionarioService
    {
        private readonly FuncionarioDAL _funcionarioDAL;

        public FuncionarioService()
        {
            _funcionarioDAL = new FuncionarioDAL();
        }

        public List<Funcionario> ObterTodosFuncionarios()
        {
            try
            {
                return _funcionarioDAL.ListarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter funcionários: " + ex.Message);
            }
        }

        public int ObterTotalFuncionarios()
        {
            try
            {
                List<Funcionario> funcionarios = _funcionarioDAL.ListarTodos();
                return funcionarios.Count;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao calcular total de funcionários: " + ex.Message);
            }
        }

        public decimal ObterMaiorSalario()
        {
            try
            {
                List<Funcionario> funcionarios = _funcionarioDAL.ListarTodos();

                if (funcionarios.Count == 0)
                {
                    return 0;
                }

                return funcionarios.Max(f => f.Salario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao calcular maior salário: " + ex.Message);
            }
        }
    }
}
