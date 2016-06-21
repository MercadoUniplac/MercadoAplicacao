using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Uniplac.Mercado.Dominio;
using Uniplac.Mercado.Dominio.Contratos;
using Uniplac.Mercado.Infra.Dados.Contexto;

namespace Uniplac.Mercado.Infra.Dados.Repositorios
{
    public class ItemVendaRepository : IItemVendaRepository
    {
        private MercadoContext _contexto;
        public ItemVendaRepository()
        {
            _contexto = new MercadoContext();
        }
        public ItemVenda Adicionar(ItemVenda itemVenda)
        {
            var resultado = _contexto.ItensVenda.Add(itemVenda);
            _contexto.SaveChanges();
            return resultado;
        }

        public ItemVenda Atualizar(ItemVenda itemVenda)
        {
            var entry = _contexto.Entry<ItemVenda>(itemVenda);
            entry.State = System.Data.Entity.EntityState.Modified;
            _contexto.SaveChanges();

            return itemVenda;
        }

        public ItemVenda Buscar(int id)
        {
            return _contexto.ItensVenda.Include(itv => itv.Produto).Where(itv => itv.Id == id).FirstOrDefault();
        }

        public List<ItemVenda> BuscarTodos()
        {
            return _contexto.ItensVenda.Include(itv => itv.Produto).ToList();
        }

        public void Deletar(ItemVenda itemVenda)
        {
            var entry = _contexto.Entry<ItemVenda>(itemVenda);
            entry.State = System.Data.Entity.EntityState.Deleted;
            _contexto.SaveChanges();
        }
    }
}