namespace GobalCache.Controllers
{
    using GobalCache.Models;
    using GobalCache.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CacheController : ControllerBase
    {

        private readonly ICacheRepository _repository;
        public CacheController(ICacheRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] CacheKey cacheKey)
        {
            string? value = _repository.Get(cacheKey);
            if (value == null)
            {
                NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public bool Post([FromQuery] CacheKey cacheKey, [Required][Range(1, 11520)] int lifeTimeMinutes, [FromBody][Required] string value)
            => _repository.Set(cacheKey, lifeTimeMinutes, value);

        [HttpGet]
        public bool Remove([FromQuery] CacheKey cacheKey)
            => _repository.Remove(cacheKey);

        [HttpGet]
        public ActionResult Increment([FromQuery] CacheKey cacheKey)
        {
            long number = _repository.Increment(cacheKey);
            if (number == 0)
            {
                return Problem();
            }

            return Ok(number);
        }
    }
}