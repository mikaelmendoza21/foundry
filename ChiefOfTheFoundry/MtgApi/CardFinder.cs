using MtgApiManager.Lib.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MtgApiManager.Lib.Core;
using ChiefOfTheFoundry.Models;

namespace ChiefOfTheFoundry.MtgApi
{
    public static class CardFinder
    {
        public static MetaCard FindMetaCardByName(string name)
        {
            CardService service = new CardService();
            Exceptional<List<MtgApiManager.Lib.Model.Card>> result = service
                .Where(c => c.Name, name)
                .All();

            if (result.IsSuccess && result.Value?[0] != null)
                return new MetaCard(result.Value[0].MultiverseId.ToString(),
                    result.Value[0].Name,
                    result.Value[0].ManaCost,
                    result.Value[0].Text,
                    result.Value[0].ImageUrl);

            return null;
        }
    }
}
