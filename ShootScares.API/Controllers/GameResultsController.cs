using Microsoft.AspNetCore.Mvc;
using ShootScares.API.Data;
using ShootScares.API.Domain.Entities;
using ShootScares.API.Models;

namespace ShootScares.API.Controllers
{
    [Route("api/game-results")]
    [ApiController]
    public class GameResultsController : ControllerBase
    {
        private readonly GameResultsRepository gameResultsRepository;
        public GameResultsController(GameResultsRepository gameResultsRepository)
        {
            this.gameResultsRepository = gameResultsRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameResultModel>> Get()
        {
            var results = gameResultsRepository.GetAll().ToList();
            var resultModels = new List<GameResultModel>();
            foreach (var result in results)
            {
                var resultModel = new GameResultModel
                {
                    Id = result.Id,
                    PlayerId = result.PlayerId,
                    Score = result.Score,
                    Date = result.Date.ToString("HH:mm dd/MM/yy"),
                };
                resultModels.Add(resultModel);
            }

            return Ok(resultModels);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameResultModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GameResultModel> GetById(int id)
        {
            var result = gameResultsRepository.Get(id).FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }
            var resultModel = new GameResultModel
            {
                Id = result.Id,
                PlayerId = result.PlayerId,
                Score = result.Score,
                Date = result.Date.ToString("HH:mm dd/MM/yy")
            };

            return Ok(resultModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GameResultModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(GameResultCreateModel model)
        {
            var added = gameResultsRepository.Add(new GameResult
            {
                PlayerId = model.PlayerId,
                Score = model.Score,
                Date = model.Date,
            });

            if (added == null)
            {
                return BadRequest();
            }

            var addedModel = new GameResultModel
            {
                Id = added.Id,
                PlayerId = added.PlayerId,
                Score = added.Score,
                Date = added.Date.ToString("HH:mm dd/MM/yy")
            };

            return CreatedAtAction(nameof(GetById),
                new { id = addedModel.Id }, addedModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            var result = gameResultsRepository.Get(id).FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }
            if (gameResultsRepository.Delete(result) == true)
            {
                return NoContent();
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Failed to delete the game results.");
        }
    }
}
