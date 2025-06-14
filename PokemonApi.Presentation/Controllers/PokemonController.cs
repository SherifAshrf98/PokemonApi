using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonApi.Application.Dtos.PokemonDtos;
using PokemonApi.Application.Interfaces;
using System.Threading.Tasks;

namespace PokemonApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPokemons()
        {
            var pokemons = await _pokemonService.GetAllPokmeonsAsync();

            if (pokemons == null)
                return NotFound();

            return Ok(pokemons);
        }

        [HttpGet("{pokemonId}")]
        public async Task<IActionResult> GetPokemon(int pokemonId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pokemon = await _pokemonService.GetPokemonByIdAsync(pokemonId);

            if (pokemon == null)
                return NotFound();

            return Ok(pokemon);
        }

        [HttpPost]
        public async Task<IActionResult> AddPokemon([FromBody] CreatePokemonDto createPokemonDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var AddedPokemon = await _pokemonService.AddPokemonAsync(createPokemonDto);

            return CreatedAtAction(nameof(GetPokemon), new { pokemonId = AddedPokemon.Id }, AddedPokemon);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePokemon(int id, UpdatePokemonDto updatePokemonDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _pokemonService.UpdatePokemonAsync(id, updatePokemonDto);

            if (!result)
                return NotFound("The Pokemon You are trying to update is not found !");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemonAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _pokemonService.DeletePokemonAsync(id);

            if (!result)
                return NotFound("The Pokemon You are trying to Delete is not found !");

            return NoContent();
        }
    }
}
