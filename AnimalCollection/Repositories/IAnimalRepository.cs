using AnimalCollection.Entities;
using AnimalCollection.DTOs;
using System.Collections.Generic;

namespace AnimalCollection.Repositories
{
    public interface IAnimalRepository
    {
        List<Animal> GetAll();
        Animal GetByID(int id);
        Animal CreateAnimal(Animal animal);
        Animal UpdateAnimal(UpdateAnimalDTO updateAnimalDTO, int id);
        void DeleteAnimal(int id);
    }
}