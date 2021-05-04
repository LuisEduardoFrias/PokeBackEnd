
using System.Collections.Generic;

namespace Entity.Models
{
    public class PokemonDetail
    {
        //[JsonPropertyName("id")]
        public int id { get; set; }
        public string name { get; set; }
        public int base_experience { get; set; }
        public int height { get; set; }
        public bool is_default { get; set; }
        public int order { get; set; }
        public int weight { get; set; }
        public string location_area_encounters { get; set; }

        public Species species { get; set; }
        public Sprites sprites { get; set; }

        public ICollection<Ability> abilities { get; set; }
        public ICollection<Form> forms { get; set; }
        public ICollection<Hold_Items> hold_items { get; set; }
        public ICollection<Move> moves { get; set; }
        public ICollection<Type> types { get; set; }
    }
}