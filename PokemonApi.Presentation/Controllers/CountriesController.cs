using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonApi.Application.Dtos.CountryDtos;
using PokemonApi.Application.Interfaces;

namespace PokemonApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var Countries = await _countryService.GetAllCountriesAsync();

            if (Countries == null)
                return NotFound("Countries Not Found");

            return Ok(Countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CountryToReturn = await _countryService.GetCountryByIdAsync(id);

            if (CountryToReturn == null)
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = $"Country with id {id} is Not Found"
                });

            return Ok(CountryToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry(CreateCountryDto createCountryDto)
        {
            var AddedCountry = await _countryService.AddCountryAsync(createCountryDto);

            return CreatedAtAction(nameof(GetCountry), new { AddedCountry.Id }, AddedCountry);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _countryService.UpdateCountryAsync(id, updateCountryDto);

            if (!result)
                return NotFound("The Country You Want To Update doesn't Exist");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var result = await _countryService.DeleteCountryAsync(id);

            if (!result)
                return NotFound("The Country You Want To Delete doesn't Exist");

            return NoContent();
        }
    }
}
