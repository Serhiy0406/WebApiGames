using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiGames.Business.DTOs;
using WebApiGames.Data.Entities;

namespace WebApiGames.Business.MapperProfile
{
    public class SourceMappingProfile : Profile
    {
        public SourceMappingProfile()
        {
            CreateMap<BlogUsers, BlogUserDTO>();
            CreateMap<Developers, DeveloperDTO>();
            CreateMap<Games, GameDTO>();
            CreateMap<Genres, GenreDTO>();
            CreateMap<Publishers, PublisherDTO>();
            CreateMap<Ratings, RatingDTO>();

            CreateMap<BlogUserDTO, BlogUsers > ();
            CreateMap< DeveloperDTO, Developers>();
            CreateMap<GameDTO, Games>();
            CreateMap< GenreDTO, Genres>();
            CreateMap<PublisherDTO, Publishers>();
            CreateMap< RatingDTO, Ratings>();
        }
    }
}
