using ChiefOfTheFoundry.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChiefOfTheFoundry.DataAccess
{
    public interface IMetaCardService
    {
        MetaCard GetOneMetaCard();
        MetaCard GetMetaCardById(string id);
        MetaCard GetMetaCardByName(string name);
        MetaCard Create(MetaCard card);
        void Update(MetaCard cardIn);
        void Remove(MetaCard cardIn);
        void Remove(string id);
    }

    public class MetaCardService : IMetaCardService
    {
        private readonly IMongoCollection<MetaCard> _metaCards;

        public MetaCardService(ICollectionDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _metaCards = database.GetCollection<MetaCard>(settings.CollectionName);
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

        public MetaCard GetMetaCardByName(string name)
        {
            return _metaCards.Find<MetaCard>(card => card.Name.ToUpper() == name.ToUpper())
            .FirstOrDefault();
        }

        public MetaCard Create(MetaCard card)
        {
            MetaCard existingCard = GetMetaCardByName(card.Name);

            if(existingCard == null)
                _metaCards.InsertOne(card);

            return existingCard ?? card;
        }

        public void Update(MetaCard cardIn)
        {
            _metaCards.ReplaceOne(card => card.Id == cardIn.Id, cardIn);
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
