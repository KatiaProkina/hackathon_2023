using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShootScares.API.Data;
using ShootScares.API.Models;

namespace ShootScares.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderBoardController : ControllerBase
    {
        private readonly PlayersRepository playersRepository;
        private readonly GameResultsRepository gameResultsRepository;

        public LeaderBoardController(PlayersRepository playersRepository,
            GameResultsRepository gameResultsRepository)
        {
            this.playersRepository = playersRepository;
            this.gameResultsRepository = gameResultsRepository;
        }

        [HttpGet]
        public ActionResult<LeaderBoardItem> Get()
        {
            var leaderBoard = new List<LeaderBoardItem>();
            var topResults = gameResultsRepository.GetTopResults(5);
            foreach (var res in topResults)
            {
                var item = new LeaderBoardItem();
                item.Username = playersRepository
                    .Get(res.PlayerId)
                    .FirstOrDefault()!
                    .Name;
                item.Score = res.Score;
                item.Date = res.Date.ToString("HH:mm dd/MM/yy");
                leaderBoard.Add(item);
            }
            return Ok(leaderBoard);
        }
    }
}
