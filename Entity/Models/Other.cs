namespace Entity.Models
{
    public class Other
    {
        public Dream_World dream_world { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("official-artwork")]
        public OfficialArtwork official_artwork { get; set; }
    }
}
