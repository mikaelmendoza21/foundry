using System;
using System.Collections.Generic;
using System.Text;
using ChiefOfTheFoundry.MtgApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FoundryInspector.MtgApiTests
{ 
    [TestClass]
    public class CardFinderTest
    {
        const string TestCardName = "Chief Of The Foundry";

        [TestMethod]
        public void FindMetaCardByName_NotNull()
        {
            var result = CardFinder.FindMetaCardByName(TestCardName);

            Assert.IsNotNull(result);
        }
    }
}
