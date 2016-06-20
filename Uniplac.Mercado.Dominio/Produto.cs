using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uniplac.Mercado.Dominio
{
    public class Produto
    {
        public Produto()
        {

        }
        public Produto(string nome, double preco)
        {
            this.Nome = nome;
            this.Preco = preco;
        }
        public int Id { get; set; }

        public string Nome { get; set; }

        public double Preco { get; set; }
    }
}
