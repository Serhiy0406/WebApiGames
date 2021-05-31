using WebApiGames.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApiGames.Data.Repositories;
using WebApiGames.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebApiGames.Data.Repositories
{
    public class PublishersRepository : BaseRepository<Publishers>, IPublishersRepository
    {
        private readonly ApplicationContext _context;
        public PublishersRepository(ApplicationContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
