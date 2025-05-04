using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relationshipTest.Data;
using relationshipTest.DTO_s;
using relationshipTest.Models;

namespace relationshipTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TlouController : ControllerBase
    {
        private readonly DataContext _context;

        public TlouController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacterById(int id)
        {
            var character = await _context.Characters
            .Include(c => c.BackPack)
            .Include(c => c.Weapons)
            .Include(c => c.Factions)
            .FirstOrDefaultAsync(c => c.Id == id);

            return Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> CreateCharacter(CharacterCreateDto request)
        {
            var newCharacter = new Character
            {
                Name = request.Name,
            };
            var backpack = new BackPack
            {
                Description = request.Backpack.Description,
                Character = newCharacter
            };
            var Weapons = request.Weapons.Select(w => new Weapon
            {
                Name = w.Name,
                Character = newCharacter
            });
            var Factions = request.Factions.Select(f => new Faction
            {
                Name = f.Name,
                Characters = new List<Character> { newCharacter }
            });

            newCharacter.BackPack = backpack;
            newCharacter.Weapons = Weapons.ToList();
            newCharacter.Factions = Factions.ToList();

            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();
            return Ok(await _context.Characters.Include(c => c.BackPack).Include(c => c.Weapons).ToListAsync());
        }
    }
}
