using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Mercado.Dominio;

namespace Uniplac.Mercado.Infra.Dados.Configurations
{
    public class VendaConfiguration : EntityTypeConfiguration<Venda>
    {
        public VendaConfiguration()
        {
            HasMany(v => v.Itens).WithRequired().WillCascadeOnDelete(true);
        }
    }
}
