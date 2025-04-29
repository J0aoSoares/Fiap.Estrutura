using System;

namespace Fiap.Estrutura.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Preço: {Preco:C}";
        }
    }
}
