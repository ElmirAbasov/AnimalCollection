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

            var animals = _repo.GetAll();
            return Ok(animals);
        }
        // GET /api/vinyl/:id
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
        public IActionResult CreateAnimal([FromBody] Animal animal )
        {
            Animal createdAnimal = _repo.CreateAnimal(animal);

            _repo.CreateAnimal(createdAnimal);
            return CreatedAtAction(
                nameof(GetAnimals),
                new { id = AnimalSavedDTO.Id },
                AnimalSavedDTO);
        
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal([FromBody] Animal animal, int id)
        {
            Animal updatedAnimal = _repo.UpdateAnimal(animal, id);
            //VinylDTO vinylDTO = updatedVinyl.MapToVinylDTO();
            Animal animalDTO = _repo.GetByID(id).MapToAnimalDTO();
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