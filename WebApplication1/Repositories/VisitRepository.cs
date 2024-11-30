public class VisitRepository : IVisitRepository
{
	private readonly IAnimalRepository _animalRepository;

	public VisitRepository(IAnimalRepository animalRepository)
	{
		_animalRepository = animalRepository;
	}

	public IEnumerable<Visit> GetVisitsByAnimalId(int animalId)
	{
		var animal = _animalRepository.GetAnimalById(animalId);
		return animal?.Visits ?? new List<Visit>();
	}

	public Visit AddVisit(int animalId, Visit visit)
	{
		var animal = _animalRepository.GetAnimalById(animalId);
		if (animal == null) return null;

		visit.Id = animal.Visits.Count > 0 ? animal.Visits.Max(v => v.Id) + 1 : 1;
		animal.Visits.Add(visit);

		return visit;
	}
}