using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniplac.Mercado.Dominio;
using Uniplac.Mercado.Dominio.Contratos;
using Moq;
using Uniplac.Mercado.Aplicacao.Contrato;
using Uniplac.Mercado.Aplicacao.Serviço;
using System.Collections.Generic;

namespace Uniplac.Mercado.Aplicacao.Testes
{
    [TestClass]
    public class ProdutoAplicacaoTeste
    {

        [TestMethod]

        public void AtualizarProdutoAplicacaoTeste()
        {
            //Monta objeto
            Produto produto = new Produto();
            produto.Nome = "Arroz";
            produto.Preco = 4.90;

            var repositorioFake = new Mock<IProdutoRepository>();
            repositorioFake.Setup(x => x.Atualizar(produto)).Returns(produto);
            IProdutoAplicacao servico = new ProdutoAplicacao(repositorioFake.Object);


            Produto novoProduto = servico.Atualizar(produto);

            repositorioFake.Verify(x => x.Atualizar(novoProduto));

        }
        [TestMethod]
        public void CriarProdutoNaAplicacaoTeste()
        {
            Produto produto = new Produto();

            produto.Nome = "Arroz";
            produto.Preco = 8.90;

            var repositorioFake = new Mock<IProdutoRepository>();
            repositorioFake.Setup(x => x.Adicionar(produto)).Returns(new Produto());

            IProdutoAplicacao servico = new ProdutoAplicacao(repositorioFake.Object);
            servico.CriarProduto(produto);
            repositorioFake.Verify(rep => rep.Adicionar(produto));

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
            IProdutoAplicacao servico = new ProdutoAplicacao(repositorioFake.Object);
            var produtoBuscado = servico.Busca(1);
            repositorioFake.Verify(rep => rep.Buscar(1));
        }

        public void BuscaTodosProdutosAplicacaoTeste()
        {
            var repositorioFake = new Mock<IProdutoRepository>();
            repositorioFake.Setup(x => x.BuscarTodos()).Returns(new List<Produto>() {
                new Produto(){
                    Nome = "Arroz",
                    Preco = 4.90,
                    Id = 1
                }
            });
            IProdutoAplicacao servico = new ProdutoAplicacao(repositorioFake.Object);
            var listProdutos = servico.BuscarTodos();
            repositorioFake.Verify(rep => rep.BuscarTodos());

        }

        [TestMethod]
        public void DeleteProdutoAplicacaoTeste()
        {

            Produto produto = new Produto();
            produto.Nome = "Pilsen";
            produto.Preco = 4.90;

            var repositorioFake = new Mock<IProdutoRepository>();
            repositorioFake.Setup(x => x.Deletar(produto));

            IProdutoAplicacao servico = new ProdutoAplicacao(repositorioFake.Object);
            Produto produtoDeletado = servico.Deletar(produto);

            repositorioFake.Verify(x => x.Deletar(produtoDeletado));

        }


    }
}

