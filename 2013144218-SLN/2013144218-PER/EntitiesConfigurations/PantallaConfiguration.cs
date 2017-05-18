using _2013144218_ENT.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013144218_PER.EntitiesConfigurations
{
    public class PantallaConfiguration : EntityTypeConfiguration<Pantalla>
    {
        public PantallaConfiguration()
        {
            HasKey(a => a.PantallaId);
            Property(v => v.Texto)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
