using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uniplac.Mercado.Dominio
{
    public class ItemVenda
    {
        public Produto Produto
        {
            get;
            set;
        }

        public int Qtd { get; set; }

        public double ObterSubTotal()
        {
            throw new System.NotImplementedException();
        }
    }
}
