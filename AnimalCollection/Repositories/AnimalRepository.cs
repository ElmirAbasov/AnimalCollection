using AnimalCollection.Entities;
using AnimalCollection.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCollection.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private List<Animal> _animals = new()
        {
            new Animal
            {
                Id = 0,
                Name = "Ko",
                Type = "Däggdjur",
            },
            new Animal
            {
                Id = 1,
                Name = "Blåval",
                Type = "Däggdjur",
            },
            new Animal
            {
                Id = 2,
                Name = "Uggla",
                Type = "Fågel",
            },
            new Animal
            {
                Id = 3,
                Name = "Lax",
                Type = "Fisk",
            }
        };

        public AnimalRepository() { }

        public List<Animal> GetAll()
        {
            return _animals;
        }

        public Animal GetByID(int id)
        {
            IEnumerable<Animal> animal = _animals.Where(item => item.Id == id);

            return animal.SingleOrDefault();
        }

        public Animal CreateAnimal(Animal animal)
        {
            animal.Id = _animals.Max(a => a.Id) + 1;
            _animals.Add(animal);

            return animal;
        }

        public Animal UpdateAnimal(UpdateAnimalDTO updateAnimalDTO, int id)
        {
            Animal updatedAnimal = new Animal
            {
                Id = id,
                Name = updateAnimalDTO.Name,
                Type = updateAnimalDTO.Type

            };

            int index = _animals.FindIndex(a => a.Id == id);
            _animals[index] = updatedAnimal;

            return updatedAnimal;
        }

        public void DeleteAnimal(int id)
        {
            int index = _animals.FindIndex(a => a.Id == id);
            _animals.RemoveAt(index);
        }

    }

}