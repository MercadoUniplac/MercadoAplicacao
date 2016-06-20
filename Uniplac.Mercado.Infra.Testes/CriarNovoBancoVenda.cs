using System;
using System.Collections.Generic;
using System.Data.Entity;
using Uniplac.Mercado.Dominio;
using Uniplac.Mercado.Infra.Dados.Contexto;

namespace Uniplac.Mercado.Infra.Testes
{
    internal class CriarNovoBancoVenda<T> : DropCreateDatabaseAlways<MercadoContext>
    {
        protected override void Seed(MercadoContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                // Criar venda
                Venda venda = new Venda(new DateTime(2000,12,30), new List<ItemVenda>());

                // Adicionar no contexto
                context.Venda.Add(venda);
            }

            // Salvar alterações
            context.SaveChanges();
            base.Seed(context);
        }
    }
}