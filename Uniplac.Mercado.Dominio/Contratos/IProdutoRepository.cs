using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Mercado.Dominio.Contratos
{
    public interface IProdutoRepository
    {
        Produto Adicionar(Produto produto);
        Produto Buscar(int id);
        List<Produto> BuscarTodos();
        Produto Atualizar(Produto produto);
        void Deletar(Produto produto); 
    }
}
