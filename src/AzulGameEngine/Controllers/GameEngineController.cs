using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AzulGameEngine.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/game")]
    public class GameEngineController : ControllerBase
    {
        public GameEngineController()
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task Create(string playerName)
        {
        }
    }
}