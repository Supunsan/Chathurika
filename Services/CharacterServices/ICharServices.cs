using System.Collections.Generic;
using System.Threading.Tasks;
using Chathurika.Dtos.Character;
using Chathurika.Models;

namespace Chathurika.Services.CharServices
{
    public interface ICharServices
    {
        Task<ServiceResaponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResaponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResaponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto req);
        Task<ServiceResaponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto req);        
        Task<ServiceResaponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}