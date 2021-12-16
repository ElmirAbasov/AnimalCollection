using AnimalCollection.Entities;
using AnimalCollection.Repositories;
using AnimalCollection.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
namespace AnimalCollection.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _repo;

        public AnimalController(IAnimalRepository repo)
        {
            _repo = repo;
        }

        // GET /api/animals
        [HttpGet]
        [Route("")]
        public IActionResult GetAnimals()
        {
            var animals = _repo.GetAll();

            return Ok(animals);
        }

        // GET /api/animals/:id
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

        // POST /api/animals
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
                new { id = newAnimal.Id },
                newAnimal);
        }

        // PUT /api/animals/:id
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal([FromBody] UpdateAnimalDTO updateAnimalDTO, int id)
        {
            Animal existing = _repo.GetByID(id);
            if (existing == null)
            {
                return NotFound("Could not find animal with ID " + id);
            }
            existing.Id = id;
            existing.Name = updateAnimalDTO.Name;
            existing.Type = updateAnimalDTO.Type;

            _repo.UpdateAnimal(updateAnimalDTO, id);

            return Ok(existing);
        }

        // DELETE /api/animals/:id
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
