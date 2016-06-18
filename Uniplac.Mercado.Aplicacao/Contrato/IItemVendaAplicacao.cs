using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Mercado.Dominio;

namespace Uniplac.Mercado.Aplicacao.Contrato
{
    public interface IItemVendaAplicacao
    {

        ItemVenda CriarItemVenda(ItemVenda itemVenda);
        ItemVenda Atualizar(ItemVenda itemVenda);
        ItemVenda Deletar(ItemVenda itemVenda);
        ItemVenda Busca(int id);
    }
}
