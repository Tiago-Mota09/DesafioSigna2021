using AutoMapper;
using DeafioSigna2021.Data.Entities;
using DeafioSigna2021.Domain.Models.Request;
using DeafioSigna2021.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeafioSigna2021.Profiles
{
    public class LikedRepositoryProfile : Profile
    {
        public LikedRepositoryProfile()
        {
            CreateMap<LikedRepositoryRequest, LikedRepositoryEntity>().ReverseMap();
            CreateMap<LikedRepositoryEntity, LikedRepositoryResponse>().ReverseMap();
            CreateMap<LikedRepositoryUpdateRequest, LikedRepositoryEntity>().ReverseMap();
        }
    }
}
