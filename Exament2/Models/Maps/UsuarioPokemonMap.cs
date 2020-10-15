using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exament2.Models.Maps
{
    public class UsuarioPokemonMap : IEntityTypeConfiguration<UsuarioPokemon>
    {
        public void Configure(EntityTypeBuilder<UsuarioPokemon> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("UsuarioPokemon");
            builder.HasKey(o => o.Id);
            builder.HasOne(o => o.pokemons)
           .WithMany()
           .HasForeignKey(o => o.PokemonId);

        }
    }
}
