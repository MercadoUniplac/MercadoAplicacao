using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniplac.Mercado.Dominio.Exceptions;

namespace Uniplac.Mercado.Dominio.Testes
{
    [TestClass]
    public class ItemVendaTest
    {
        [TestMethod]
        public void Obter_SubTotal_Item_Venda_Test()
        {
            ItemVenda itemVenda = new ItemVenda();
            itemVenda.Qtd = 10;
            itemVenda.Produto = new Produto("Arroz", 15);
            Assert.AreEqual(150, itemVenda.ObterSubTotal());
        }


        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Obter_SubTotal_Produto_Nulo_Item_Venda_Test()
        {
            ItemVenda itemVenda = new ItemVenda();
            itemVenda.Qtd = 10;
            itemVenda.ObterSubTotal();
        }
    }
}
