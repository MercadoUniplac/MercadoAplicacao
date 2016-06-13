using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Mercado.Dominio.Contratos
{
    public interface IItemVendaRepository
    {
        ItemVenda Adicionar(ItemVenda itemVenda);
        ItemVenda Buscar(int id);
        List<ItemVenda> BuscarTodos();
        ItemVenda Atualizar(ItemVenda itemVenda);
        void Deletar(ItemVenda itemVenda); 
    }
}
