using Microsoft.AspNetCore.Mvc;
using ShootScares.API.Data;
using ShootScares.API.Domain.Entities;
using ShootScares.API.Models;

namespace ShootScares.API.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PlayersRepository playersRepository;
        public PlayersController(PlayersRepository playersRepository)
        {
            this.playersRepository = playersRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlayerModel>> Get()
        {
            var players = playersRepository.GetAll().ToList();

            var playersModels = new List<PlayerModel>();

            foreach (var player in players)
            {
                var resultsModels = new List<GameResultModel>();
                foreach (var result in player.Results)
                {
                    resultsModels.Add(new GameResultModel()
                    {
                        Score = result.Score,
                        Date = result.Date.ToString("HH:mm dd/MM/yy")
                    });
                }

                var playerModel = new PlayerModel();
                playerModel.Id = player.Id;
                playerModel.Name = player.Name;
                playerModel.Results = resultsModels;
                playersModels.Add(playerModel);
            }

            return Ok(playersModels);
        }

        [HttpGet("{id}")]
        public ActionResult<PlayerModel> GetById(int id)
        {
            var player = playersRepository.Get(id).FirstOrDefault();

            if (player == null)
            {
                return NotFound();
            }

            var results = new List<GameResultModel>();
            foreach (var result in player.Results.ToList())
            {
                var resultModel = new GameResultModel();
                resultModel.Score = result.Score;
                resultModel.Date = result.Date.ToString("HH:mm dd/MM/yy");
                results.Add(resultModel);
            }

            var model = new PlayerModel()
            {
                Id = player.Id,
                Name = player.Name,
                Results = results
            };

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] string name)
        {
            var player = playersRepository.Add(new Player { Name = name });
            return CreatedAtAction(nameof(GetById), 
                new { id = player.Id }, player);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            var player = playersRepository.Get(id).FirstOrDefault();

            if (player == null)
            {
                return NotFound();
            }
            player.Name = name;
            playersRepository.Update(player);

            return Ok(player);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var player = playersRepository.Get(id).FirstOrDefault();
            if (player == null)
            {
                return NotFound();
            }

            if (playersRepository.Delete(player) == true)
            {
                return NoContent();
            }

            return StatusCode(StatusCodes.Status500InternalServerError, 
                "Failed to delete the player.");
        }
    }
}
