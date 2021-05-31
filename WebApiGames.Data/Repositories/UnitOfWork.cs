using System;
using System.Collections.Generic;
using System.Text;
using WebApiGames.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using WebApiGames.Data.Entities;
using System.Threading.Tasks;

namespace WebApiGames.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext context;
        public IGenresRepository GenresRepository { get; }
        public IDevelopersRepository DevelopersRepository { get; }
        public IPublishersRepository PublishersRepository { get; }
        public IRatingsRepository RatingsRepository { get; }
        public IBlogUsersRepository BlogUsersRepository { get; }
        public IGamesRepository GamesRepository { get; }
        public UnitOfWork(ApplicationContext context,
            IGenresRepository genresRepository,
            IDevelopersRepository developersRepository,
            IPublishersRepository publishersRepository,
            IBlogUsersRepository blogusersRepository,
            IRatingsRepository ratingsRepository,
            IGamesRepository gamesRepository
            )
        {
            this.context = context;
            GenresRepository = genresRepository;
            DevelopersRepository = developersRepository;
            PublishersRepository = publishersRepository;
            RatingsRepository = ratingsRepository;
            BlogUsersRepository = blogusersRepository;
            GamesRepository = gamesRepository;
        }


        //Dispose Pattern
        private bool disposed = false;

        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    context.Dispose();
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
