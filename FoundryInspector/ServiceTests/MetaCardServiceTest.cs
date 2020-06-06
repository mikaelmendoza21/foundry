using System;
using System.Collections.Generic;
using System.Text;
using ChiefOfTheFoundry.DataAccess;
using ChiefOfTheFoundry.Models;
using ChiefOfTheFoundry.MtgApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FoundryInspector.ServiceTests
{
    [TestClass]
    public class MetaCardServiceTest
    {
        const string ConnString = "mongodb://localhost:27017";
        const string DbName = "FoundryDb";
        const string SetsCollection = "Sets";
        const string MetaCardsCollection = "MetaCards";

        // Sample MetaCard
        const string SampleCardName = "Chief of the Foundry";
        const string SampleCardObjectID = "5ed5e403facabe0be4e6e9e8"; // Use values form your own Db

        [TestMethod]
        public void GetCardByIdTest()
        {
            // Arrange
            CollectionDbSettings metaCardsDbSettings = new CollectionDbSettings()
            {
                CollectionName = MetaCardsCollection,
                ConnectionString = ConnString,
                DatabaseName = DbName
            };
            MetaCardAccessor metaService = new MetaCardAccessor(metaCardsDbSettings);

            // Act
            MetaCard metaCard = metaService.GetMetaCardById(SampleCardObjectID);

            // Assert
            Assert.IsNotNull(metaCard);
            Assert.IsTrue(metaCard.Name == SampleCardName);
        }
    }
}
