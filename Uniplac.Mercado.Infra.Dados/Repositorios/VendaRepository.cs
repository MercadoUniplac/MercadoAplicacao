using System;
using System.Collections.Generic;
using System.Linq;
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
            return _contexto.Venda.Find(id);
        }

        public List<Venda> BuscarTodos()
        {
            return _contexto.Venda.ToList();
        }

        public void Deletar(Venda venda)
        {
            var entry = _contexto.Entry<Venda>(venda);
            entry.State = System.Data.Entity.EntityState.Deleted;
            _contexto.SaveChanges();
        }
    }
}