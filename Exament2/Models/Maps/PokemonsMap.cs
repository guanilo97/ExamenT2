using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exament2.Models.Maps
{
    public class PokemonsMap : IEntityTypeConfiguration<Pokemons>
    {
        public void Configure(EntityTypeBuilder<Pokemons> builder)
        {
            // throw new NotImplementedException();
            builder.ToTable("Pokemons");
            builder.HasKey(o => o.Id);
            builder.HasOne(o => o.tipo)
            .WithMany()
            .HasForeignKey(o => o.TipoId);



        }
    }
}
