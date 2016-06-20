using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uniplac.Mercado.Dominio.Exceptions;

namespace Uniplac.Mercado.Dominio
{
    public class ItemVenda
    {
        public ItemVenda()
        {

        }
        public ItemVenda(Produto produto, int qtd)
        {
            Produto = produto;
            Qtd = qtd;
        }
        public int Id { get; set; }
        public Produto Produto { get; set; }

        public int Qtd { get; set; }


        public double ObterSubTotal()
        {
            if (this.Produto == null)
                throw new BusinessException("O Produto do item de venda não pode ser nulo");
            return this.Qtd * this.Produto.Preco;
        }
    }
}
