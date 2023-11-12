using ShootScares.API.Domain;
using ShootScares.API.Domain.Entities;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ShootScares.API.Data
{
    public class GameResultsRepository : EfCoreRepository<GameResult, GameDbContext>
    {
        public GameResultsRepository(GameDbContext context) : base(context) { }

        public List<GameResult> GetTopResults(int count)
        {
            var results = context.Set<GameResult>()
                .OrderByDescending(r => r.Score)
                .Take(count)
                .ToList();
            return results;
        }
    }
}
