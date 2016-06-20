using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Mercado.Dominio;
using Uniplac.Mercado.Infra.Dados.Configurations;

namespace Uniplac.Mercado.Infra.Dados.Contexto
{
    public class MercadoContext : DbContext
    {
        public MercadoContext() : base("MercadoDB")
        {
                
        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<ItemVenda> ItensVenda { get; set; }

        public DbSet<Venda> Venda { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new VendaConfiguration());
        }

    }
}
