public class AnimalRepository : IAnimalRepository
{
	private readonly List<Animal> _animals;

	public AnimalRepository()
	{
		_animals = new List<Animal>
			{
				new Animal { Id = 1, Name = "Buddy", Category = "Dog", Weight = 10.5f, FurColor = "Brown" },
				new Animal { Id = 2, Name = "Whiskers", Category = "Cat", Weight = 4.2f, FurColor = "Black" }
			};
	}

	public IEnumerable<Animal> GetAllAnimals()
	{
		return _animals;
	}

	public Animal GetAnimalById(int id)
	{
		return _animals.FirstOrDefault(a => a.Id == id);
	}

	public Animal AddAnimal(Animal animal)
	{
		animal.Id = _animals.Count > 0 ? _animals.Max(a => a.Id) + 1 : 1;
		_animals.Add(animal);
		return animal;
	}

	public Animal UpdateAnimal(Animal updatedAnimal)
	{
		var animal = _animals.FirstOrDefault(a => a.Id == updatedAnimal.Id);
		if (animal == null) return null;

		animal.Name = updatedAnimal.Name;
		animal.Category = updatedAnimal.Category;
		animal.Weight = updatedAnimal.Weight;
		animal.FurColor = updatedAnimal.FurColor;

		return animal;
	}

	public bool DeleteAnimal(int id)
	{
		var animal = _animals.FirstOrDefault(a => a.Id == id);
		if (animal == null) return false;

		_animals.Remove(animal);
		return true;
	}
}