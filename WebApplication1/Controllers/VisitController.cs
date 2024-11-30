
using Microsoft.AspNetCore.Mvc;

[Route("api/animals/{animalId}/[controller]")]
[ApiController]
public class VisitsController : ControllerBase
{
    private readonly IVisitRepository _visitRepository;

    public VisitsController(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }

    [HttpGet]
    public IActionResult GetVisits(int animalId)
    {
        var visits = _visitRepository.GetVisitsByAnimalId(animalId);
        if (visits == null)
            return NotFound();
        return Ok(visits);
    }

    [HttpPost]
    public IActionResult AddVisit(int animalId, [FromBody] Visit visit)
    {
        var addedVisit = _visitRepository.AddVisit(animalId, visit);
        if (addedVisit == null)
            return NotFound();
        return CreatedAtAction(nameof(GetVisits), new { animalId = animalId }, addedVisit);
    }
}