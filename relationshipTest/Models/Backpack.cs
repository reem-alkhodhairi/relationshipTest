using System.Text.Json.Serialization;

namespace relationshipTest.Models
{
    public class BackPack
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CharacterId { get; set; }
        [JsonIgnore]
        public Character Character { get; set; }    
    }
}
