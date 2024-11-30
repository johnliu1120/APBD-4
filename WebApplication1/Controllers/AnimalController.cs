
using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalsController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(_animalRepository.GetAllAnimals());
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            var animal = _animalRepository.GetAnimalById(id);
            if (animal == null)
                return NotFound();
            return Ok(animal);
        }

        [HttpPost]
        public IActionResult AddAnimal([FromBody] Animal animal)
        {
            var addedAnimal = _animalRepository.AddAnimal(animal);
            return CreatedAtAction(nameof(GetAnimal), new { id = addedAnimal.Id }, addedAnimal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, [FromBody] Animal updatedAnimal)
        {
            updatedAnimal.Id = id;
            var animal = _animalRepository.UpdateAnimal(updatedAnimal);
            if (animal == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var success = _animalRepository.DeleteAnimal(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }