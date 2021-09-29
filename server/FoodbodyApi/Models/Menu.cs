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

        [Required]
        public string Name { get; set; }

        [Required]
        public int Calories { get; set; }

        public string ImageUrl { get; set; }
    }

    public class MenuDetail {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        public double Protein { get; set; }

        [Required]
        public double Carb { get; set; }

        [Required]
        public double Fat { get; set; }

        [Required]
        public int Serve { get; set; }

        [Required]
        public string Unit { get; set; }

        public string ImageUrl { get; set; }

        public string Barcode { get; set; }
    }
}