using Microsoft.EntityFrameworkCore;
using ShootScares.API.Domain;
using ShootScares.API.Domain.Entities;

namespace ShootScares.API.Data
{
    public class PlayersRepository : EfCoreRepository<Player, GameDbContext>
    {
        public PlayersRepository(GameDbContext context) : base(context) { }

        public new IQueryable<Player> Get(int id) => context.Set<Player>()
            .Where(p => p.Id == id)
            .Include(p => p.Results)
            .AsQueryable();

        public new IQueryable<Player> GetAll() => context.Set<Player>()
            .Include(p => p.Results)
            .AsQueryable();
    }
}
