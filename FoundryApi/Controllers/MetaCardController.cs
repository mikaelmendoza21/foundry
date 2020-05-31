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
        private readonly ILogger<MetaCardController> _logger;
        private readonly MetaCardService _metaCardService;

        public MetaCardController(MetaCardService metaCardService)
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
    }
}
