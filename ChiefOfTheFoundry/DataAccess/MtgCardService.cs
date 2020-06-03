using ChiefOfTheFoundry.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChiefOfTheFoundry.DataAccess
{
    public interface IMtgCardService
    {
        MtgCard GetMtgCardByName(string name, string setId);
        MtgCard GetMtgCardById(string id);
        MtgCard Create(MtgCard card);
        void Update(MtgCard cardIn);
        void Remove(MtgCard setIn);
        void Remove(string id);
    }

    public class MtgCardService : IMtgCardService
    {
        private readonly IMongoCollection<MtgCard> _cards;

        public MtgCardService(ICollectionDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _cards = database.GetCollection<MtgCard>(settings.CollectionName);
        }

        public MtgCard GetMtgCardByName(string name, string setId)
        {
            return _cards
                .Find<MtgCard>(card => card.Name == name && card.SetID == setId)
                .FirstOrDefault();
        }

        public MtgCard GetMtgCardById(string id)
        {
            return _cards.Find<MtgCard>(card => card.Id == id)
            .FirstOrDefault();
        }

        public MtgCard Create(MtgCard card)
        {
            MtgCard existingCard = GetMtgCardByName(card.Name, card.SetID);
            
            if (existingCard == null)
                _cards.InsertOne(card);
                
            return existingCard ?? card;
        }

        public void Update(MtgCard cardIn)
        {
            _cards.ReplaceOne(set => set.Id == cardIn.Id, cardIn);
        }

        public void Remove(MtgCard setIn)
        {
            _cards.DeleteOne(set => set.Id == setIn.Id);
        }

        public void Remove(string id)
        {
            _cards.DeleteOne(set => set.Id == id);
        }
    }
}
