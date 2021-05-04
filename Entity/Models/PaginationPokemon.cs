using System.Collections.Generic;

namespace Entity.Models
{
    public class PaginationPokemon
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previeus { get; set; }
        public ICollection<Pokemon> results { get; set; }
    }
}
