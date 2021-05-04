namespace Entity.Models
{
    public class Versions
    {
        [System.Text.Json.Serialization.JsonPropertyName("generation-i")]
        public GenerationI generationi { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("generation-ii")]
        public GenerationIi generationii { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("generation-iii")]
        public GenerationIii generationiii { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("generation-iv")]
        public GenerationIv generationiv { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("generation-v")]
        public GenerationV generationv { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("generation-vi")]
        public GenerationVi generationvi { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("generation-vii")]
        public GenerationVii generationvii { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("generation-viii")]
        public GenerationViii generationviii { get; set; }
    }
}
