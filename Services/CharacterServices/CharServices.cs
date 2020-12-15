using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chathurika.Dtos.Character;
using Chathurika.Models;

namespace Chathurika.Services.CharServices
{
    public class CharServices : ICharServices
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{Id = 2, Name = "Rumi",Age=26},
            new Character{Id = 3, Name = "Chathu",Age=27}
        };
        private readonly IMapper _mapper;
        public CharServices(IMapper mapper)
        {
            _mapper = mapper;

        }

        public async Task<ServiceResaponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto req)
        {
            ServiceResaponse<List<GetCharacterDto>> serviceResaponse = new ServiceResaponse<List<GetCharacterDto>>();
            try
            {
                characters.Add(_mapper.Map<Character>(req));
                serviceResaponse.Data = (characters.Select(a => _mapper.Map<GetCharacterDto>(a))).ToList();
            }
            catch (Exception ex)
            {
                serviceResaponse.Success = false;
                serviceResaponse.Message = ex.Message;
            }
            return serviceResaponse;
        }

        public async Task<ServiceResaponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResaponse<List<GetCharacterDto>> serviceResaponse = new ServiceResaponse<List<GetCharacterDto>>();
            try
            {
                serviceResaponse.Data = (characters.Select(a => _mapper.Map<GetCharacterDto>(a))).ToList();
            }
            catch (Exception ex)
            {
                serviceResaponse.Success = false;
                serviceResaponse.Message = ex.Message;
            }
            return serviceResaponse;
        }

        public async Task<ServiceResaponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResaponse<GetCharacterDto> serviceResaponse = new ServiceResaponse<GetCharacterDto>();
            try
            {
                serviceResaponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(a => a.Id == id));
            }
            catch (Exception ex)
            {
                serviceResaponse.Success = false;
                serviceResaponse.Message = ex.Message;
            }
            return serviceResaponse;
        }

        public async Task<ServiceResaponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto req)
        {
            ServiceResaponse<GetCharacterDto> serviceResaponse = new ServiceResaponse<GetCharacterDto>();
            try
            {
                Character character = characters.FirstOrDefault(a => a.Id == req.Id);
                character.Name = req.Name;
                character.Age = req.Age;

                serviceResaponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                serviceResaponse.Success = false;
                serviceResaponse.Message = ex.Message;
            }
            return serviceResaponse;
        }
        public async Task<ServiceResaponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResaponse<List<GetCharacterDto>> serviceResaponse = new ServiceResaponse<List<GetCharacterDto>>();
            try
            {
                Character character = characters.First(a => a.Id == id);
                characters.Remove(character);

                serviceResaponse.Data = (characters.Select(a => _mapper.Map<GetCharacterDto>(a))).ToList();
            }
            catch (Exception ex)
            {
                serviceResaponse.Success = false;
                serviceResaponse.Message = ex.Message;
            }
            return serviceResaponse;
        }

    }
}