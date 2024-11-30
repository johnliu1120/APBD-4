public interface IVisitRepository
{
    IEnumerable<Visit> GetVisitsByAnimalId(int animalId);
    Visit AddVisit(int animalId, Visit visit);
}