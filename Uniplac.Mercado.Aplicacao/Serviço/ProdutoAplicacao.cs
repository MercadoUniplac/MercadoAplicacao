using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Mercado.Aplicacao.Contrato;
using Uniplac.Mercado.Dominio;
using Uniplac.Mercado.Dominio.Contratos;

namespace Uniplac.Mercado.Aplicacao.Serviço
{
    public class ProdutoAplicacao : IProdutoAplicacao
    {
        private IProdutoRepository _repositorio;

        public ProdutoAplicacao(IProdutoRepository repositorio)
        {
            this._repositorio = repositorio;
        }

        public Produto Atualizar(Produto produto)
        {
            Produto produtoAtualizado = _repositorio.Atualizar(produto);

            return produtoAtualizado;
        }

        public Produto Busca(int id)
        {
            Produto produto = _repositorio.Buscar(id);
            return produto;
        }

        public List<Produto> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }

        public Produto CriarProduto(Produto produto)
        {
            return _repositorio.Adicionar(produto);
        }

        public Produto Deletar(Produto produto)
        {
            _repositorio.Deletar(produto);
            return produto;
        }
    }
}
