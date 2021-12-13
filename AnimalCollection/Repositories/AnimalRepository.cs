using AnimalCollection.Entities;
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
                Name = "ko",
                Type = "däggdjur",

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
            _animals.Add(animal);

            return animal;
        }

        public Animal UpdateAnimal(Animal animal)
        {
            int index = _animals.FindIndex(item => item.Id == animal.Id);
   
                _animals[index] = animal;

            return animal;
        }

        public void DeleteAnimal(int id)
        {
            int index = _animals.FindIndex(xanimal => xanimal.Id == id);
            _animals.RemoveAt(index);
        }

    }

}