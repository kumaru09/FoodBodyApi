using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FoodbodyApi.Models {
    public class Menu {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Id { get; set; }

        [Key]
        [Required]
        public string menu_id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public int calories { get; set; }

        [Required]
        public double protein { get; set; }

        [Required]
        public double carb { get; set; }

        [Required]
        public double fat { get; set; }

        [Required]
        public string imageUrl { get; set; }
    }
}