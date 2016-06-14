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
            itemVenda.Qtd=2;

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

        }
    }
}
