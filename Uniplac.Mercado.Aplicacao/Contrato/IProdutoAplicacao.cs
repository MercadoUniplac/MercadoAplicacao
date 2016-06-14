using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Mercado.Dominio;

namespace Uniplac.Mercado.Aplicacao.Contrato
{
    public interface IProdutoAplicacao
    {
        
        Produto CriarProduto(Produto produto);
        Produto Atualizar(Produto produto);
        Produto Deletar(Produto produto);
        Produto Busca(int id);

    }
}
