using System.Collections.Generic;

namespace Entity.Dtos
{
    public class PaginationPokemonDto
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previeus { get; set; }
        public ICollection<PokemonDto> results { get; set; }
    }
}
