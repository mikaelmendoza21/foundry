using System;
using System.Collections.Generic;
using System.Text;

namespace ChiefOfTheFoundry.Models
{
    public class MetaCardDbSettings : IMetaCardsDbSettings
    {
        public string MetaCardsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMetaCardsDbSettings
    {
        string MetaCardsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
