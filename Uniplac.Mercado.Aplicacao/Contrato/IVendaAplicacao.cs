using System.Collections.Generic;
using Uniplac.Mercado.Dominio;

namespace Uniplac.Mercado.Aplicacao.Contrato
{
    public interface IVendaAplicacao
    {

        Venda CriarVenda(Venda venda);
        Venda Atualizar(Venda venda);
        Venda Deletar(Venda venda);
        Venda Busca(int id);
        List<Venda> BuscarTodos();
    }
}