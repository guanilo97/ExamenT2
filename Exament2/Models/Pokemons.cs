using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exament2.Models
{
    public class Pokemons
    {
      
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string Nombre { get; set; }
        public int TipoId { get; set; }
        public string Imagen { get; set; }
      
        public Tipo tipo { get; set; }

      }
}
