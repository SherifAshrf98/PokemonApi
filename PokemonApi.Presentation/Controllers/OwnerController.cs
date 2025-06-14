using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonApi.Application.Dtos.OwnerDtos;
using PokemonApi.Application.Interfaces;
using System.Runtime.InteropServices;

namespace PokemonApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            var Owners = await _ownerService.GetAllOwnersAsync();

            if (Owners == null)
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = $"Owners list is Empty"
                });

            return Ok(Owners);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwner(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Owner = await _ownerService.GetOwnerAsync(id);

            if (Owner == null)
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = $"Owner with id {id} is not Found"
                });

            return Ok(Owner);
        }

        [HttpPost]
        public async Task<IActionResult> AddOwner(CreateOwnerDto createOwnerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var AddedOwner = await _ownerService.AddOwnerAsync(createOwnerDto);

            return CreatedAtAction(nameof(GetOwner), new { id = AddedOwner.Id }, AddedOwner);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(int id, UpdateOwnerDto updateOwnerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _ownerService.UpdateOwnerAsync(id, updateOwnerDto);

            if (!result)
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = $"Owner with id {id} is not Found"
                });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _ownerService.DeleteOwnerAsync(id);

            if (!result)
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = $"Owner with id {id} is not Found"
                });

            return NoContent();
        }

    }
}