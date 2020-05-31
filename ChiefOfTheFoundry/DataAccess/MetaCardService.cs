using ChiefOfTheFoundry.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChiefOfTheFoundry.DataAccess
{
    public class MetaCardService
    {
        private readonly IMongoCollection<MetaCard> _metaCards;

        public MetaCardService(IMetaCardsDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _metaCards = database.GetCollection<MetaCard>(settings.MetaCardsCollectionName);
        }

        public MetaCard GetOneMetaCard()
        {
            return _metaCards
                .Find<MetaCard>(card => true)
                .FirstOrDefault();
        }

        public MetaCard GetMetaCardById(string id)
        {
            return _metaCards.Find<MetaCard>(card => card.Id == id)
            .FirstOrDefault();
        }

        public MetaCard Create(MetaCard card)
        {
            _metaCards.InsertOne(card);
            return card;
        }

        public void Update(string id, MetaCard cardIn)
        {
            _metaCards.ReplaceOne(card => card.Id == id, cardIn);
        }

        public void Remove(MetaCard cardIn)
        {
            _metaCards.DeleteOne(card => card.Id == cardIn.Id);
        }

        public void Remove(string id)
        {
            _metaCards.DeleteOne(card => card.Id == id);
        }
    }
}
