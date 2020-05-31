using ChiefOfTheFoundry.DataAccess;
using ChiefOfTheFoundry.Models;
using ChiefOfTheFoundry.MtgApi;
using MtgApiManager.Lib.Model;
using System;

namespace RetrofitterFoundry
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You've casted Retrofitter Foundry");
            Console.WriteLine("This will populate your local database with MetaCard data");

            MetaCard aMetaCard = FetchAnyMetaCard();

            Console.WriteLine($"Found card with name: ${aMetaCard.Name}");

            MetaCardDbSettings dbSettings = new MetaCardDbSettings()
            {
                MetaCardsCollectionName = "MetaCards",
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "FoundryDb"
            };

            MetaCardService service = new MetaCardService(dbSettings);
            MetaCard createdCard = service.Create(aMetaCard);

            Console.WriteLine($"Saved to Db with Id: ${createdCard.Id}");
        }

        private static MetaCard FetchAnyMetaCard()
        {
            return CardFinder.FindRandomMetaCard();
        }
    }
}
