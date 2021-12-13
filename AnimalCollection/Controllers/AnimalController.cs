using AnimalCollection.Entities;
using AnimalCollection.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
namespace AnimalCollection.Controllers
{
    [ApiController]
    [Route("api/animal")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _repo;

        public AnimalController(IAnimalRepository repo)
        {
            _repo = repo;
        }
        // GET /api/animal
        [HttpGet]
        [Route("")]
        public IActionResult GetAnimals()
        {

            var animals = _repo.GetAll();
            return Ok(animals);
        }
        // GET /api/animal/:id
        [HttpGet("{id}")]
        public IActionResult GetAnimalsByID(int id)
        {
            Animal animal = _repo.GetByID(id);
            if (animal is null)
            {
                return NotFound("Could not find animal with ID " + id);
            }
            return Ok(animal);
        }
        [HttpPost("")]
        public IActionResult CreateAnimal([FromBody] Animal animal)
        {
            Animal newAnimal = new()
            {
                Id = animal.Id,
                Name = animal.Name,
                Type = animal.Type
            };

            _repo.CreateAnimal(newAnimal);
            return CreatedAtAction(
                nameof(GetAnimals),
                new { id = newAnimal.Id},
                newAnimal);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal([FromBody] Animal animal)
        {
            Animal existing = _repo.GetByID(animal.Id);
            if (existing == null)
            {
                return NotFound("Could not find animal with ID " + animal.Id);
            }
            existing.Name = animal.Name;
            existing.Type = animal.Type;
            _repo.UpdateAnimal(existing);
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            Animal existing = _repo.GetByID(id);
            if (existing == null)
            {
                return NotFound("Could not find animal with ID " + id);
            }
            _repo.DeleteAnimal(id);
            return NoContent();
        }
    }
}
