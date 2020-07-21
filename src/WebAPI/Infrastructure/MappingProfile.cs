using AutoMapper;
using OnlineReader.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Infrastructure
{
    /// <summary>
    /// Класс для автомаппера.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<CreateModel, AppUser>()
                .ForMember(
                    dest =>
                dest.UserName,
                    opt => щзopt.MapFrom(src => src.Name));
        }
    }
}
