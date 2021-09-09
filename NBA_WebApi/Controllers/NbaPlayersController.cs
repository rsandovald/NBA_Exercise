
using Microsoft.AspNetCore.Mvc;
using NBA_BusinessRules;
using NBA_Entities;
using NBA_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace NBA_WebApi.Controllers
{
    [Route("api/NbaPlayers")]
    public class NbaPlayersController : ControllerBase
    {
        private readonly INbaPlayerRepository _repository;

        public NbaPlayersController (INbaPlayerRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet("{targetHeight:int}")]
        public async Task<List<Tuple<NBA_Player, NBA_Player>>> Get(int targetHeight)
        {
            NbaPlayerCalculator obj = new NbaPlayerCalculator(this._repository);
            return  await obj.getPairsOfPlayers(targetHeight);            
        }
    }
}
