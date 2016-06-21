using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Mercado.Aplicacao.Contrato;
using Uniplac.Mercado.Aplicacao.Serviço;
using Uniplac.Mercado.Dominio;
using Uniplac.Mercado.Dominio.Contratos;

namespace Uniplac.Mercado.Aplicacao.Testes
{
    public class ItemVendaAplicacaoTeste
    {
        [TestMethod]

        public void AtualizarProdutoAplicacaoTeste()
        {
            //Monta objeto
            ItemVenda itemVenda = new ItemVenda();
            itemVenda.Produto = new Produto();
            itemVenda.Qtd = 2;

            var repositorioFake = new Mock<IItemVendaRepository>();
            repositorioFake.Setup(x => x.Atualizar(itemVenda)).Returns(itemVenda);
            IItemVendaAplicacao servico = new ItemVendaAplicacao(repositorioFake.Object);


            ItemVenda novoItemVenda = servico.Atualizar(itemVenda);

            repositorioFake.Verify(x => x.Atualizar(novoItemVenda));

        }

        [TestMethod]
        public void CriarItemVendaNaAplicacaoTeste()
        {
            ItemVenda itemVenda = new ItemVenda();

            itemVenda.Produto = new Produto();
            itemVenda.Qtd = 2;

            var repositorioFake = new Mock<IItemVendaRepository>();
            repositorioFake.Setup(x => x.Adicionar(itemVenda)).Returns(new ItemVenda());

            IItemVendaAplicacao servico = new ItemVendaAplicacao(repositorioFake.Object);
            servico.CriarItemVenda(itemVenda);
            repositorioFake.Verify(x => x.Adicionar(itemVenda));

        }

        [TestMethod]
        public void BuscaItemVendaAplicacaoTeste()
        {
            //Monta objeto
            ItemVenda itemVenda = new ItemVenda();
            itemVenda.Produto = new Produto();
            itemVenda.Qtd = 4;


            var repositorioFake = new Mock<IItemVendaRepository>();
            repositorioFake.Setup(x => x.Buscar(1)).Returns(new ItemVenda()
            {
                Produto = itemVenda.Produto,
                Qtd = itemVenda.Qtd,
                Id = 1

            });
            IItemVendaAplicacao servico = new ItemVendaAplicacao(repositorioFake.Object);
            servico.Busca(1);
            repositorioFake.Verify(x => x.Buscar(1));
        }


        [TestMethod]
        public void BuscaItemVendaTodosAplicacaoTeste()
        {
            //Monta objeto
            ItemVenda itemVenda = new ItemVenda();
            itemVenda.Produto = new Produto();
            itemVenda.Qtd = 4;

            var repositorioFake = new Mock<IItemVendaRepository>();
            repositorioFake.Setup(x => x.BuscarTodos()).Returns(new List<ItemVenda>(){
                itemVenda
            });
            IItemVendaAplicacao servico = new ItemVendaAplicacao(repositorioFake.Object);
            servico.BuscaTodos();
            repositorioFake.Verify(rep => rep.BuscarTodos());
        }

        [TestMethod]
        public void DeleteItemVendaAplicacaoTeste()
        {

            ItemVenda itemVenda = new ItemVenda();
            itemVenda.Produto = new Produto();
            itemVenda.Qtd = 4;

            var repositorioFake = new Mock<IItemVendaRepository>();
            repositorioFake.Setup(x => x.Deletar(itemVenda));

            IItemVendaAplicacao servico = new ItemVendaAplicacao(repositorioFake.Object);
            ItemVenda itemVendaDeletado = servico.Deletar(itemVenda);

            repositorioFake.Verify(x => x.Deletar(itemVendaDeletado));

        }


    }
}
