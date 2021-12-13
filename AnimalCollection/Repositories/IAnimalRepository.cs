using AnimalCollection.Entities;
using System.Collections.Generic;

namespace AnimalCollection.Repositories
{
    public interface IAnimalRepository
    {
        List<Animal> GetAll();
        Animal GetByID(int id);
        Animal CreateAnimal(Animal animal);
        Animal UpdateAnimal(Animal animal);
        void DeleteAnimal(int id);
    }
}