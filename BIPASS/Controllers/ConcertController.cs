using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BIPASS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConcertController : ControllerBase
    {
        private readonly IConcertRepository _concertRepository;

        public ConcertController(IConcertRepository concertRepository)
        {
            _concertRepository = concertRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var concerts = await _concertRepository.GetAllAsync();
            return Ok(concerts);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateConcertRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var concert = new Concert
            {
                Title = request.Title,
                Venue = request.Venue,
                City = request.City,
                EventDateUtc = request.EventDateUtc,
                IsStreamingEnabled = request.IsStreamingEnabled,
                StreamingUrl = request.StreamingUrl
            };

            var created = await _concertRepository.AddAsync(concert);
            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }

        public class CreateConcertRequest
        {
            public string Title { get; set; } = string.Empty;
            public string Venue { get; set; } = string.Empty;
            public string City { get; set; } = string.Empty;
            public DateTime EventDateUtc { get; set; }
            public bool IsStreamingEnabled { get; set; }
            public string? StreamingUrl { get; set; }
        }
    }
}