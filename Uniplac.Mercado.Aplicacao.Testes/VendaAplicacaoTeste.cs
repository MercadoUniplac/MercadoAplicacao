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
    [TestClass]
    public class VendaAplicacaoTeste
    {

        public void AtualizarVendaAplicacaoTeste()
        {
            //Monta objeto
            Venda venda = new Venda();
            venda.Itens = new List<ItemVenda>();
            venda.Data = new DateTime();

            var repositorioFake = new Mock<IVendaRepository>();
            repositorioFake.Setup(x => x.Atualizar(venda)).Returns(venda);
            IVendaAplicacao servico = new VendaAplicacao(repositorioFake.Object);


            Venda novoVenda = servico.Atualizar(venda);

            repositorioFake.Verify(x => x.Atualizar(novoVenda));

        }
        [TestMethod]
        public void CriarVendaNaAplicacaoTeste()
        {
            Venda venda = new Venda();

            venda.Itens = new List<ItemVenda>();
            venda.Data = new DateTime();

            var repositorioFake = new Mock<IVendaRepository>();
            repositorioFake.Setup(x => x.Adicionar(venda)).Returns(new Venda());

            IVendaAplicacao servico = new VendaAplicacao(repositorioFake.Object);


        }

        [TestMethod]
        public void BuscaVendaAplicacaoTeste()
        {
            //Monta objeto
            var repositorioFake = new Mock<IVendaRepository>();
            repositorioFake.Setup(x => x.Buscar(1)).Returns(new Venda()
            {
                Itens = new List<ItemVenda>(),
                Data = new DateTime(),
                Id = 1
            });
            IVendaAplicacao servico = new VendaAplicacao(repositorioFake.Object);
            servico.Busca(1);
            repositorioFake.Verify(x => x.Buscar(1));

        }

        [TestMethod]
        public void BuscaVendaTodosAplicacaoTeste()
        {
            //Monta objeto
            var repositorioFake = new Mock<IVendaRepository>();
            repositorioFake.Setup(x => x.BuscarTodos()).Returns(new List<Venda>(){ 
                new Venda() {
                    Itens = new List<ItemVenda>(),
                    Data = DateTime.Now,
                    Id = 1
                }
            });
            IVendaAplicacao servico = new VendaAplicacao(repositorioFake.Object);
            servico.BuscarTodos();
            repositorioFake.Verify(x => x.BuscarTodos());
        }

        [TestMethod]
        public void DeleteVendaAplicacaoTeste()
        {

            Venda venda = new Venda();
            venda.Itens = new List<ItemVenda>();
            venda.Data = new DateTime();

            var repositorioFake = new Mock<IVendaRepository>();
            repositorioFake.Setup(x => x.Deletar(venda));

            IVendaAplicacao servico = new VendaAplicacao(repositorioFake.Object);
            Venda vendaDeletada = servico.Deletar(venda);
            repositorioFake.Verify(x => x.Deletar(vendaDeletada));
        }


    }
}
