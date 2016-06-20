using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Uniplac.Mercado.Dominio.Testes
{
    [TestClass]
    public class VendaTest
    {
        [TestMethod]
        public void Obter_Total_Venda_Test()
        {
            Produto produto1 = new Produto("Arroz", 5);
            Produto produto2 = new Produto("Feijão", 10);

            ItemVenda itemVenda1 = new ItemVenda();
            itemVenda1.Produto = produto1;
            itemVenda1.Qtd = 2;
            ItemVenda itemVenda2 = new ItemVenda();
            itemVenda2.Produto = produto2;
            itemVenda2.Qtd = 3;

            Venda venda = new Venda();
            venda.Data = DateTime.Now;
            venda.Itens.Add(itemVenda1);
            venda.Itens.Add(itemVenda2);

            Assert.AreEqual(40, venda.ObterTotalVenda());
        }

        public void Obter_Total_Venda_Sem_Subitens_Test()
        {
            Venda venda = new Venda();
            venda.Data = DateTime.Now;
            Assert.AreEqual(0, venda.ObterTotalVenda());
        }
    }
}
