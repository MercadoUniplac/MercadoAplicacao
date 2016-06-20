using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uniplac.Mercado.Dominio
{
    public class Venda
    {

        public int Id { get; set; }

        public DateTime Data { get; set; }

        public List<ItemVenda> Itens { get; set; }

        public Venda()
        {
            this.Itens = new List<ItemVenda>();
        }

        public double ObterTotalVenda()
        {
            double total = 0;
            foreach (var item in this.Itens)
            {
                total += item.ObterSubTotal();
            }
            return total;
        }
    }
}
