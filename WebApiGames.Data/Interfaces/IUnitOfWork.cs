using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiGames.Data.Entities;

namespace WebApiGames.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IGenresRepository GenresRepository { get; }

        //public UserManager<BlogUsers> UserManager { get; }
        //public RoleManager<IdentityRole> RoleManager { get; }
       //public SignInManager<BlogUsers> SignInManager { get; }

        IDevelopersRepository DevelopersRepository { get; }
        IPublishersRepository PublishersRepository { get; }
        IRatingsRepository RatingsRepository { get; }
        IBlogUsersRepository BlogUsersRepository { get; }
        IGamesRepository GamesRepository { get; }


        Task<int> Complete();

        //public IGenericRepository<Entity> GetRepository<Entity>() where Entity : class;
    }
}
