using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniplac.Mercado.Dominio;
using Uniplac.Mercado.Dominio.Contratos;
using Moq;
using Uniplac.Mercado.Aplicacao.Contrato;
using Uniplac.Mercado.Aplicacao.Serviço;

namespace Uniplac.Mercado.Aplicacao.Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CriarProdutoNaAplicacaoTeste()
        {
            Produto produto = new Produto();

            produto.Nome = "Arroz";
            produto.Preco = 8.90;

            var repositorioFake = new Mock<IProdutoRepository>();
            repositorioFake.Setup(x => x.Adicionar(produto)).Returns(new Produto());

            IProdutoAplicacao servico = new ProdutoAplicacao(repositorioFake.Object);


        }

        [TestMethod]
        public void BuscaProdutoAplicacaoTeste()
        {
            //Monta objeto
            Produto produto = new Produto();
            produto.Nome = "Arroz";
            produto.Preco = 4.90;



            var repositorioFake = new Mock<IProdutoRepository>();
            repositorioFake.Setup(x => x.Buscar(1)).Returns(new Produto()
            {
                Nome = "Arroz",
                Preco = 4.90,
                Id = 1
            });
        }
    }
}
       
