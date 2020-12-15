using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chathurika.Dtos.Character;
using Chathurika.Models;
using Chathurika.Services.CharServices;
using Microsoft.AspNetCore.Mvc;

namespace Chathurika.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharServices _charServices;

        public CharacterController(ICharServices charServices)
        {
            _charServices = charServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _charServices.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _charServices.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto req)
        {
            return Ok(await _charServices.AddCharacter(req));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSample(UpdateCharacterDto req)
        {
            ServiceResaponse<GetCharacterDto> resaponse = await _charServices.UpdateCharacter(req);
            
            if(resaponse.Data == null)
                return NotFound(resaponse);

            return Ok(resaponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            ServiceResaponse<List<GetCharacterDto>> resaponse = await _charServices.DeleteCharacter(id);

            if (resaponse.Data == null)
                return NotFound(resaponse);

            return Ok(resaponse);
        }

    }
}