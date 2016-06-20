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
            nome = Nome;
            preco = Preco;
        }
        public int Id { get; set; }

        public string Nome { get; set; }

        public double Preco { get; set; }

        public Produto()
        {

        }

        public Produto(string nome, double preco)
        {
            this.Nome = nome;
            this.Preco = preco;
        }


        public override string ToString()
        {
            return String.Format("{0}: R$ {1}", this.Nome, this.Preco);
        }
    }
}
