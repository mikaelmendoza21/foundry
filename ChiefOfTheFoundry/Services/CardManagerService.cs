using ChiefOfTheFoundry.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChiefOfTheFoundry.Services
{
    public interface ICardManagerService
    {
        
    }

    public class CardManagerService : ICardManagerService
    {
        IMetaCardAccessor _metaCardAccessor;
        IMtgSetAccessor _setAccessor;
        IMtgCardAccessor _mtgCardAccessor;
        ICardConstructAccessor _cardConstructAccesor;

        public CardManagerService(IMetaCardAccessor metaCardAccessor,
            IMtgSetAccessor setAccessor,
            IMtgCardAccessor mtgCardAccessor,
            ICardConstructAccessor cardConstructAccesor)
        {
            _metaCardAccessor = metaCardAccessor;
            _setAccessor = setAccessor;
            _mtgCardAccessor = mtgCardAccessor;
            _cardConstructAccesor = cardConstructAccesor;
        }
    }
}
