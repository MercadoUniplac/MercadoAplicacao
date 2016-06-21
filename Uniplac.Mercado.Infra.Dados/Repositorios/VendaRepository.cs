using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Uniplac.Mercado.Dominio;
using Uniplac.Mercado.Dominio.Contratos;
using Uniplac.Mercado.Infra.Dados.Contexto;

namespace Uniplac.Mercado.Infra.Dados.Repositorios
{
    public class VendaRepository : IVendaRepository
    {
        private MercadoContext _contexto;
        public VendaRepository()
        {
            _contexto = new MercadoContext();
        }
        public Venda Adicionar(Venda venda)
        {
            venda.Itens.ToList().ForEach(item => {
                item.Produto = _contexto.Produtos.Find(item.Produto.Id);
            });
            var resultado = _contexto.Venda.Add(venda);
            _contexto.SaveChanges();
            return resultado;
        }

        public Venda Atualizar(Venda venda)
        {
            var entry = _contexto.Entry<Venda>(venda);
            entry.State = System.Data.Entity.EntityState.Modified;
            _contexto.SaveChanges();

            return venda;
        }

        public Venda Buscar(int id)
        {
            var venda = _contexto.Venda.Include(v => v.Itens).Where(v => v.Id == id).FirstOrDefault();
            for (int i = 0; i < venda.Itens.Count; i++)
            {
                var idItem = venda.Itens[i].Id;
                venda.Itens[i] = _contexto.ItensVenda.Include(itv => itv.Produto).Where(itv => itv.Id == idItem).FirstOrDefault();
                
            }
            return venda;
        }

        public List<Venda> BuscarTodos()
        {
            var vendas = _contexto.Venda.Include(v => v.Itens).ToList();
            foreach (var venda in vendas)
            {
                for (int i = 0; i < venda.Itens.Count; i++)
                {
                    var id = venda.Itens[i].Id;
                    venda.Itens[i] = _contexto.ItensVenda.Include(itv => itv.Produto).Where(itv => itv.Id == id).FirstOrDefault();

                }
            }
            return vendas;
        }

        public void Deletar(Venda venda)
        {
            venda.Itens.ToList().ForEach(item => {
                var entryItem = _contexto.Entry<ItemVenda>(item);
                entryItem.State = EntityState.Deleted;
            });
            var entry = _contexto.Entry<Venda>(venda);
            entry.State = EntityState.Deleted;
            _contexto.SaveChanges();
        }
    }
}