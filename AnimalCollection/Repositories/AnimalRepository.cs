using AnimalCollection.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCollection.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private List<Animal> _animals;

        public AnimalRepository() { }

        public List<Animal> GetAll()
        {
            return _animals;
        }

        public Animal GetByID(int id)
        {
            Animal Animal = _animals.Find(id);
            return Animal;
        }

        public Animal CreateAnimal(Animal animal)
        {
            _animals.Add(animal);

            return animal;
        }

        public Animal UpdateAnimal(Animal animal, int id)
        {
            Animal currentAnimal = _animals.FirstOrDefault(item => item.Id == animal.Id);
            if (currentAnimal != null)
            {
                currentAnimal.Name = Animal.Name;
                currentAnimal.Type = Animal.Type;

            }

            return currentAnimal;
        }

        public void DeleteAnimal(int id)
        {
            _animals.Remove(GetByID(id));
        }

    }

}