namespace GobalCache.Controllers
{
    using GobalCache.Models;
    using GobalCache.Repositories;
    using Microsoft.AspNetCore.Mvc;

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
        public ActionResult Get(int bookingSiteId, string method, string dictionaryName, string key)
        {
            var value = _repository.GetValue(bookingSiteId, method, dictionaryName, key);

            if (!string.IsNullOrEmpty(value))
            {
                return Ok(value);
            }

            return NotFound();
        }
        
        [HttpPost]
        public void Post(int bookingSiteId, string method, string dictionaryName, string key, int lifeTimeMinutes, [FromBody] string value)
        {
            _repository.SetValue(bookingSiteId, method, dictionaryName, key, lifeTimeMinutes, value);
        }
    }
}
