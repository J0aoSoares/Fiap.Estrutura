using System;
using System.Collections.Generic;
using System.Linq;
using Fiap.Estrutura.DAL;
using Fiap.Estrutura.Model;

namespace Fiap.Estrutura.BLL
{
    public class ProdutoService
    {
        private readonly ProdutoDAL _produtoDAL;

        public ProdutoService()
        {
            _produtoDAL = new ProdutoDAL();
        }

        public List<Produto> ObterTodosProdutos()
        {
            try
            {
                return _produtoDAL.ListarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter produtos: " + ex.Message);
            }
        }

        public int ObterTotalProdutos()
        {
            try
            {
                List<Produto> produtos = _produtoDAL.ListarTodos();
                return produtos.Count;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao calcular total de produtos: " + ex.Message);
            }
        }

        public decimal ObterPrecoMedio()
        {
            try
            {
                List<Produto> produtos = _produtoDAL.ListarTodos();

                if (produtos.Count == 0)
                {
                    return 0;
                }

                return produtos.Average(p => p.Preco);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao calcular preço médio: " + ex.Message);
            }
        }
    }
}
