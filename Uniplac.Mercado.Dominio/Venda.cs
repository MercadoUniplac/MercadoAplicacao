using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uniplac.Mercado.Dominio
{
    public class Venda
    {

        public DateTime Data { get; set; }

        public List<ItemVenda> Itens { get; set; }

        public double ObterTotalVenda()
        {
            throw new System.NotImplementedException();
        }
    }
}
