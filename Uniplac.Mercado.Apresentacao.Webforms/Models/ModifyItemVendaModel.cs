using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uniplac.Mercado.Dominio;

namespace Uniplac.Mercado.Apresentacao.Webforms.Models
{
    public class ModifyItemVendaModel
    {
        public int Id { get; set; }


        public Venda Venda { get; set; }

        public List<SelectListItem> Produtos { get; set; }

        public string IdProdutoSelecionado { get; set; }

        public int Qtd { get; set; }

        public ModifyItemVendaModel()
        {

        }

        public ModifyItemVendaModel(Venda venda, List<Produto> produtos)
        {
            this.Produtos = new List<SelectListItem>();
            this.Venda = venda;
            foreach (var produto in produtos)
            {
                var item = new SelectListItem()
                {
                    Text = produto.Nome,
                    Value = produto.Id.ToString(),
                    Selected = this.Produtos.Count == 0
                };
                this.Produtos.Add(item);
            }
        }
    }
}