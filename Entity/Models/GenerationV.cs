namespace Entity.Models
{
    public class GenerationV
    {
        [System.Text.Json.Serialization.JsonPropertyName("black-white")]
        public BlackWhite blackwhite { get; set; }
    }

    public class BlackWhite
    {
        public Animated animated { get; set; }
    }
}
