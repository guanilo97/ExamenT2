using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exament2.Models
{
    public class UsuarioPokemon
    {
        public int Id { get; set; }
        public int UsuarioId{get;set;}
        public int PokemonId { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Imagen { get; set; }

        public Pokemons pokemons { get;set; }
    }
}
