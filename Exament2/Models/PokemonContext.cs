using Exament2.Models.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exament2.Models
{
    public class PokemonContext : DbContext
    {
        public DbSet<Pokemons> pokemons { get; set; }
        public DbSet<Tipo> tipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioPokemon> usuarioPokemons { get; set; }
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //esto se hace por cada tabla en la base de datos
            modelBuilder.ApplyConfiguration(new PokemonsMap());
            modelBuilder.ApplyConfiguration(new TipoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new UsuarioPokemonMap());
        }
    }
}
