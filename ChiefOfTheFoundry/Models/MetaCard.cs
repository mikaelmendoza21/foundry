using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChiefOfTheFoundry.Models
{
    /// <summary>
    /// Defines a Card by name. Basic definition of a card instance, does not contain specific set, cost information.
    /// </summary>
    public class MetaCard : MasterMTGCard
    {
        private static Uri DefaultImage = new Uri("https://www.pcgamesn.com/wp-content/uploads/2019/06/mtg-arena-core-set-2020.jpg");

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Uri ImageUrl { get; set; }

        /* Constructors */ 
        public MetaCard(string id) 
        {
            this.Id = id;
        }

        public MetaCard(string id, string name, string manaCost, string text, Uri imageUrl)
        {
            this.Id = id;
            this.Name = name;
            this.ManaCost = manaCost;
            this.Text = text;
            this.ImageUrl = imageUrl ?? DefaultImage;
        }
    }
}
