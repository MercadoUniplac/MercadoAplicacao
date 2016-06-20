using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniplac.Mercado.Infra.Dados.Contexto;
using Uniplac.Mercado.Dominio.Contratos;
using System.Data.Entity;
using Uniplac.Mercado.Infra.Dados.Repositorios;
using Uniplac.Mercado.Dominio;
using System.Linq;
using System.Collections.Generic;

namespace Uniplac.Mercado.Infra.Testes
{
    [TestClass]
    public class ItemVendaDadosTeste
    {
        private MercadoContext _contextoTeste;
        private IItemVendaRepository _repositorio;


        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new CriarNovoBancoItemVenda<MercadoContext>());
            _contextoTeste = new MercadoContext();
            _contextoTeste.Database.Initialize(true);
            _repositorio = new ItemVendaRepository();
        }

        [TestCleanup]
        public void Clear()
        {

        }
        [TestMethod]
        public void CriarItemVendaRepositorioTeste()
        {
            // Criar item no banco
            Produto produto = new Produto("Café", 5.79);
            ItemVenda itemVenda = new ItemVenda(produto, 3);

            // Adicionar ao banco
            _repositorio.Adicionar(itemVenda);

            // Buscar no banco
            ItemVenda novoItemVenda = _contextoTeste.ItensVenda.Include(itv => itv.Produto).Where(itv => itv.Id == itemVenda.Id).FirstOrDefault();

            // Assert
            Assert.IsTrue(novoItemVenda.Id > 0);
            Assert.AreEqual(novoItemVenda.Produto.Id, produto.Id);
            Assert.AreEqual(novoItemVenda.Qtd, 3);
        }

        [TestMethod]
        public void RetornarItemVendaRepositorioTeste()
        {
            // Buscar no banco
            ItemVenda itemVenda = _repositorio.Buscar(1);
            // Assert
            Assert.IsNotNull(itemVenda);
        }

        [TestMethod]
        public void RetornarTodosItensVendaRepositorioTeste()
        {
            // Buscar tudo no banco
            List<ItemVenda> itensVenda = _repositorio.BuscarTodos();

            // Assert
            Assert.AreEqual(10, itensVenda.Count);
        }

    }
}
