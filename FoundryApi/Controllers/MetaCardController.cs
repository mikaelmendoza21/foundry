using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiefOfTheFoundry.DataAccess;
using ChiefOfTheFoundry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FoundryApi.Controllers
{
    [ApiController]
    [Route("api/metacard")]
    public class MetaCardController : ControllerBase
    {
        private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly IMetaCardService _metaCardService;

        public MetaCardController(IMetaCardService metaCardService)
        {
            _metaCardService = metaCardService;
        }

        [HttpGet]
        public IEnumerable<MetaCard> Get()
        {
            return new List<MetaCard>()
            {
                _metaCardService.GetOneMetaCard()
            };
        }

        [HttpGet]
        public MetaCard Get(string cardName)
        {
            try
            {
                return _metaCardService.GetMetaCardByName(cardName);
            }
            catch (Exception e)
            {
                logger.Info($"Error fetching card with name '{cardName}'=> {e.Message} - {e.StackTrace}");
                return null;
            }
        }

        [HttpGet]
        public MetaCard GetById(string id)
        {
            try
            {
                return _metaCardService.GetMetaCardById(id);
            }
            catch (Exception e)
            {
                logger.Info($"Error fetching card with id '{id}'=> {e.Message} - {e.StackTrace}");
                return null;
            }
        }
    }
}
