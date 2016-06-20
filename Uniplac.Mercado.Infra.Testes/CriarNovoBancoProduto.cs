using System.Data.Entity;
using Uniplac.Mercado.Dominio;
using Uniplac.Mercado.Infra.Dados.Contexto;

namespace Uniplac.Mercado.Infra.Testes
{
    public class CriarNovoBancoProduto<T> : DropCreateDatabaseAlways<MercadoContext>
    {
        protected override void Seed(MercadoContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                // Criar produto
                Produto produto = new Produto("Produto_" + i, 2.99);

                // Adicionar ao contexto
                context.Produtos.Add(produto);
            }

            // Salvar no contexto
            context.SaveChanges();
            base.Seed(context);
        }

    }
}