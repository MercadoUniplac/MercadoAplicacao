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

        public List<SelectListItem> Produtos { get; set; }

        public string IdProdutoSelecionado { get; set; }

        public int Qtd { get; set; }
    }
}