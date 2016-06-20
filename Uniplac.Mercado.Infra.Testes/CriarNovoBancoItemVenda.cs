using System.Data.Entity;
using Uniplac.Mercado.Dominio;
using Uniplac.Mercado.Infra.Dados.Contexto;

namespace Uniplac.Mercado.Infra.Testes
{
    internal class CriarNovoBancoItemVenda<T> : DropCreateDatabaseAlways<MercadoContext>
    {
        protected override void Seed(MercadoContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                // Criar item venda com o produto
                ItemVenda itemVenda = new ItemVenda(new Produto("Oreo " + i, 2.99 + i), 10);

                // Adicionar no contexto
                context.ItensVenda.Add(itemVenda);
            }

            // Salvar alterações
            context.SaveChanges();
            base.Seed(context);
        }
    }
}