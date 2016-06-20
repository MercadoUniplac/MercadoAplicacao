using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uniplac.Mercado.Dominio;

namespace Uniplac.Mercado.Apresentacao.Webforms.Models
{
    public class VendaModel
    {
        public Venda Venda { get; set; }

        public int TotalVenda { get; set; }
    }
}