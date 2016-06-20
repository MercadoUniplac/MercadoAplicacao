using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uniplac.Mercado.Dominio;

namespace Uniplac.Mercado.Apresentacao.Webforms.Models
{
    public class VendaModel
    {
        public Venda Venda { get; set; }

        public List<SelectListItem> Produtos { get; set; }

        public List<SelectListItem> Qtds { get; set; }


        public int NumItemVenda { get; set; }


        public List<double> TotalItemVenda { get; set; }

        public double TotalVenda { get; set; }

        public VendaModel()
        {

        }

        public VendaModel(Venda venda)
        {
            this.Venda = venda;
            this.TotalVenda = venda.ObterTotalVenda();
            TotalItemVenda = new List<double>();
            Produtos = new List<SelectListItem>();
            Qtds = new List<SelectListItem>();
            NumItemVenda = venda.Itens.Count;
            foreach (var item in venda.Itens)
            {
                TotalItemVenda.Add(item.ObterSubTotal());
                Produtos.Add(new SelectListItem()
                {
                    Value = item.Produto.Id.ToString()
                });
                Qtds.Add(new SelectListItem()
                {
                    Value = item.Qtd.ToString()
                });
            }
        }

    }
}