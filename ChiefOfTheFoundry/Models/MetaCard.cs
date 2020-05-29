using System;
using System.Collections.Generic;
using System.Text;

namespace ChiefOfTheFoundry.Models
{
    /// <summary>
    /// Defines a Card by name. Basic definition of a card instance, does not contain specific set, cost information.
    /// </summary>
    public class MetaCard : MasterMTGCard
    {
        private static Uri DefaultImage = new Uri("https://www.pcgamesn.com/wp-content/uploads/2019/06/mtg-arena-core-set-2020.jpg");

        public Uri ImageUrl { get; set; }
        public MetaCard(string id) 
        {
            this.ID = id;
        }

        public MetaCard(string id, string name, string manaCost, string text, Uri imageUrl)
        {
            this.ID = id;
            this.Name = name;
            this.ManaCost = manaCost;
            this.Text = text;
            this.ImageUrl = imageUrl ?? DefaultImage;
        }
        public string ID { get; set; }
    }
}
