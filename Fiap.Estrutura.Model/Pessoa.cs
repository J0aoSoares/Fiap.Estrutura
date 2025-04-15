using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Estrutura.Model
{
    public class Pessoa
    {
        public string cpf { get; set; }

        public string nome { get; set; }

        public DateTime dtNascimento { get; set; }

        public string? dsEndereco { get; set; }
    }
}
