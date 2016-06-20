using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Mercado.Dominio;
using Uniplac.Mercado.Dominio.Contratos;
using Uniplac.Mercado.Infra.Dados.Contexto;

namespace Uniplac.Mercado.Infra.Dados.Repositorios
{
    public class ProdutoRepository : IProdutoRepository
    {
        private MercadoContext _contexto;

        public ProdutoRepository()
        {
            _contexto = new MercadoContext();
        }

        public Produto Adicionar(Produto produto)
        {
            var resultado = _contexto.Produtos.Add(produto);
            _contexto.SaveChanges();
            return resultado;
        }

        public Produto Atualizar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto Buscar(int id)
        {
            return _contexto.Produtos.Find(id);
        }

        public List<Produto> BuscarTodos()
        {
            return _contexto.Produtos.ToList();
        }

        public void Deletar(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
