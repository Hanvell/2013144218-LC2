using _2013144218_ENT.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013144218_PER.EntitiesConfigurations
{
    public class CuentaConfiguration : EntityTypeConfiguration<Cuenta>
    {
        public CuentaConfiguration()
        {
            HasKey(a => a.CuentaId);
            Property(v => v.Monto)
                .IsRequired();
            Property(v => v.NumeroCuenta)
                .IsRequired();
            Property(v => v.Pin)
                .IsRequired();
        }
    }
}
