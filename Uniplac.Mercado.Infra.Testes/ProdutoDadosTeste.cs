using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Uniplac.Mercado.Infra.Dados.Contexto;
using Uniplac.Mercado.Infra.Dados.Repositorios;
using Uniplac.Mercado.Dominio;

namespace Uniplac.Mercado.Infra.Testes
{
    [TestClass]
    public class ProdutoDadosTeste
    {
        private MercadoContext _contextoTeste;
        private ProdutoRepository _repositorio;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MercadoContext>());

            _contextoTeste = new MercadoContext();
            _repositorio = new ProdutoRepository();

            _contextoTeste.Database.Initialize(true);

            _contextoTeste.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

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
    }
}
