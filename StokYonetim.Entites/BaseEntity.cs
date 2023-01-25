using System.Text.Json.Serialization;

namespace StokYonetim.Entites
{
    public abstract class BaseEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
