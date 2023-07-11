using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travel.API.Contracts;
using Travel.API.Entities;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationRepository _repository;
        public DestinationController(IDestinationRepository repository) { 
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            throw new Exception("Sta ima danas kod vas?");
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var result = await _repository.GetByConditionAsync(t => t.Id == id);

            if (result is null)
            {
                NotFound();
            }

            return Ok(result);
        }
    }
}
