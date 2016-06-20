using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Mercado.Dominio.Contratos
{
    public interface IVendaRepository
    {
        Venda Adicionar(Venda venda);
        Venda Buscar(int id);
        List<Venda> BuscarTodos();
        Venda Atualizar(Venda venda);
        void Deletar(Venda venda);
    }
}
