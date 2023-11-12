using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
                        Id = result.Id,
                        PlayerId = result.PlayerId,
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlayerModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PlayerModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            var player = playersRepository.Add(new Player { Name = name });
            var model = new PlayerModel { Id = player.Id, Name = player.Name};

            return CreatedAtAction(nameof(GetById), 
                new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlayerModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, [FromBody] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest();
            }

            var player = playersRepository.Get(id).FirstOrDefault();

            if (player == null)
            {
                return NotFound();
            }
            player.Name = name;
            var updated = playersRepository.Update(player);
            var model = new PlayerModel
            {
                Id = updated.Id,
                Name = updated.Name
            };

            return Ok(model);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
