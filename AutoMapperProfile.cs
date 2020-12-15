using AutoMapper;
using Chathurika.Dtos.Character;
using Chathurika.Models;

namespace Chathurika
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}