using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Uniplac.Mercado.Infra.Dados.Contexto;
using Uniplac.Mercado.Infra.Dados.Repositorios;
using Uniplac.Mercado.Dominio;
using System.Collections.Generic;
using Uniplac.Mercado.Dominio.Contratos;

namespace Uniplac.Mercado.Infra.Testes
{
    [TestClass]
    public class ProdutoDadosTeste
    {
        private MercadoContext _contextoTeste;
        private IProdutoRepository _repositorio;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new CriarNovoBancoProduto<MercadoContext>());
            _contextoTeste = new MercadoContext();
            _contextoTeste.Database.Initialize(true);
            _repositorio = new ProdutoRepository();
        }

        [TestCleanup]
        public void Clear()
        {

        }

        [TestMethod]
        public void CriarProdutoRepositorioTeste()
        {
            // Arrange - criar produto para persistir no banco
            Produto produto = new Produto();
            produto.Nome = "Leite";
            produto.Preco = 2.39;

            // Action - salva no banco
            _repositorio.Adicionar(produto);

            // Action - busca no banco
            Produto novoProduto = _contextoTeste.Produtos.Find(produto.Id);

            // Assert
            Assert.IsTrue(novoProduto.Id > 0);
            Assert.AreEqual(novoProduto.Nome, "Leite");
            Assert.AreEqual(novoProduto.Preco, 2.39);
        }

        [TestMethod]
        public void RetornarProdutoRepositorioTeste()
        {
            // Action - busca no banco e pá
            Produto produto = _repositorio.Buscar(1);

            // Assert - verifica se puxou o bagulho lá
            Assert.IsNotNull(produto);
        }

        [TestMethod]
        public void RetornaTodosOsProdutosRepositorioTeste()
        {
            // Action - busca no banco
            List<Produto> produtos = _repositorio.BuscarTodos();

            // Assert - verificar se obteve os produtos
            Assert.AreEqual(10, produtos.Count);
        }
    }
}
