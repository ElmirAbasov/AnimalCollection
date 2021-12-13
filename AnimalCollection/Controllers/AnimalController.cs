using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
namespace AnimalCollection.Controllers
{
    [ApiController]
    [Route("api/vinyl")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _repo;

        public AnimalController(IAnimalRepository repo)
        {
            _repo = repo;
        }
        // GET /api/vinyl
        [HttpGet]
        [Route("")]
        public IActionResult GetAnimals()
        {
            var animals = _repo
                .GetAll()
                .ToList()
                .MapToAnimalsDTOs();
            return Ok(animals);
        }
        // GET /api/vinyl/:id
        [HttpGet("{id}")]
        public IActionResult GetAnimalsByID(int id)
        {
            Animal animal = _repo.GetByID(id);
            if (animal is null) // vinyl == null
            {
                return NotFound("Could not find vinyl with ID " + id);
            }
            AnimalDTO animalDTO = animal.MapToVinylDTO();
            return Ok(animalDTO);
        }
        [HttpPost("")]
        public IActionResult CreateAnimal([FromBody] CreateAnimalDTO createdAnimalDTO)
        {
            Animal createdAnimal = _repo.CreateAnimal(createAnimalDTO);
            //VinylDTO vinylDTO = createdVinyl.MapToVinylDTO();
            AnimalDTO animalSavedDTO = _repo
                .GetByID(createdAnimal.Id)
                .MapToAnimalDTO();
            return CreatedAtAction(
                nameof(GetAnimalByID),
                new { id = AnimalSavedDTO.Id },
                AnimalSavedDTO);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal([FromBody] Animal animal, int id)
        {
            Animal updatedAnimal = _repo.UpdateAnimal(animal, id);
            //VinylDTO vinylDTO = updatedVinyl.MapToVinylDTO();
            AnimalDTO animalDTO = _repo.GetByID(id).MapToAnimalDTO();
            return Ok(animalDTO);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            _repo.DeleteAnimal(id);
            return NoContent();
        }
    }
}