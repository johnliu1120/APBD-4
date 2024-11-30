public interface IAnimalRepository
{
    IEnumerable<Animal> GetAllAnimals();
    Animal GetAnimalById(int id);
    Animal AddAnimal(Animal animal);
    Animal UpdateAnimal(Animal animal);
    bool DeleteAnimal(int id);
}