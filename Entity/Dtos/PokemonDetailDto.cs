
using System.Collections.Generic;

namespace Entity.Dtos
{
    public class PokemonDetailDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string urlImage { get; set; }
        public int base_experience { get; set; }
        public int height { get; set; }
        public int weight { get; set; }

        public ICollection<AbilityDto> abilities { get; set; }
        public ICollection<MoveDto> moves { get; set; }
        public ICollection<TypeDto> types { get; set; }
    }
}