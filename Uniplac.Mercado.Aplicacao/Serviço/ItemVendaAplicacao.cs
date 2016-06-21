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
    public class ItemVendaAplicacao : IItemVendaAplicacao
    {
        private IItemVendaRepository _repositorio;

        public ItemVendaAplicacao(IItemVendaRepository repositorio)
        {
            this._repositorio = repositorio;
        }

        public ItemVenda Atualizar(ItemVenda itemVenda)
        {
            ItemVenda itemVendaAtualizado = _repositorio.Atualizar(itemVenda);

            return itemVendaAtualizado;
        }

        public ItemVenda Busca(int id)
        {
            ItemVenda itemVenda = _repositorio.Buscar(id);
            return itemVenda;
        }

        public ItemVenda CriarItemVenda(ItemVenda itemVenda)
        {
            return _repositorio.Adicionar(itemVenda);
        }

        public ItemVenda Deletar(ItemVenda itemVenda)
        {
            _repositorio.Deletar(itemVenda);
            return itemVenda;
        }

        public List<ItemVenda> BuscaTodos()
        {
            return _repositorio.BuscarTodos();
        }
    }
}
