using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniplac.Mercado.Dominio;
using System.Collections.Generic;
using Uniplac.Mercado.Dominio.Contratos;
using Uniplac.Mercado.Infra.Dados.Contexto;
using System.Data.Entity;
using Uniplac.Mercado.Infra.Dados.Repositorios;

namespace Uniplac.Mercado.Infra.Testes
{
    [TestClass]
    public class VendaDadosTeste
    {
        private MercadoContext _contextoTeste;
        private IVendaRepository _repositorio;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new CriarNovoBancoVenda<MercadoContext>());
            _contextoTeste = new MercadoContext();
            _contextoTeste.Database.Initialize(true);
            _repositorio = new VendaRepository();
        }

        [TestCleanup]
        public void Clear()
        {
             
        }
        [TestMethod]
        public void CriarVendaRepositorioTeste()
        {
            // Criar venda
            Venda venda = new Venda(new DateTime(2000,12,30), new List<ItemVenda>());

            // Adicionar ao banco
            _repositorio.Adicionar(venda);

            // Buscar no banco
            Venda novaVenda = _contextoTeste.Venda.Find(venda.Id); //.Include(itv => itv.Produto).Where(itv => itv.Id == itemVenda.Id).FirstOrDefault();

            // Assert
            Assert.IsTrue(novaVenda.Id > 0);
            Assert.AreEqual(novaVenda.Data, new DateTime(2000, 12, 30));
        }
        [TestMethod]
        public void RetornarVendaRepositorioTeste()
        {
            // Buscar no banco
            Venda venda = _repositorio.Buscar(1);
            // Assert
            Assert.IsNotNull(venda);
        }
        [TestMethod]
        public void RetornarTodasVendasRepositorioTeste()
        {
            // Buscar tudo no banco
            List<Venda> vendas = _repositorio.BuscarTodos();

            // Assert
            Assert.AreEqual(10, vendas.Count);
        }

        
    }
}
