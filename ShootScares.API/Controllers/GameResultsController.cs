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
                var resultModel = new GameResultModel();
                resultModel.Id = result.Id;
                resultModel.PlayerId = result.PlayerId;
                resultModel.Score = result.Score;
                resultModel.Date = result.Date.ToString("HH:mm dd/MM/yy");
                resultModels.Add(resultModel);
            }

            return Ok(resultModels);
        }

        [HttpGet("{id}")]
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
            return CreatedAtAction(nameof(GetById),
                new { id = added.Id}, added);
        }

        [HttpDelete("{id}")]
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
