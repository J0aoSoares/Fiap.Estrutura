﻿using System;

namespace Fiap.Estrutura.Model
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Salário: {Salario:C}";
        }
    }
}
