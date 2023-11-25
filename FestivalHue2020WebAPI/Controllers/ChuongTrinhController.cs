using AutoMapper;
using FestivalHue2020WebAPI.DTO;
using FestivalHue2020WebAPI.Interfaces;
using FestivalHue2020WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestivalHue2020WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuongTrinhController : ControllerBase
    {
        private readonly IChuongTrinhRepository _chuongTrinhRepository;
        private readonly IMapper _mapper;

        public ChuongTrinhController(IChuongTrinhRepository chuongTrinhRepository,
            IMapper mapper)
        {
            _chuongTrinhRepository = chuongTrinhRepository ?? throw new ArgumentNullException(nameof(chuongTrinhRepository));
            _mapper = mapper;
        }

        // GET api/ChuongTrinh
        [HttpGet]
        public async Task<IActionResult> GetAllChuongTrinhs()
        {

            var chuongTrinh = _mapper.Map<List<ChuongTrinhDTO>>(await _chuongTrinhRepository.GetAllChuongTrinhsAsync());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(chuongTrinh);
        }

        // GET api/ChuongTrinh/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChuongTrinhById(int id)
        {
            var chuongTrinh = _mapper.Map<ChuongTrinhDTO>(await _chuongTrinhRepository.GetChuongTrinhByIdAsync(id));

            if (chuongTrinh == null)
                return NotFound();

            return Ok(chuongTrinh);
        }

        // POST api/ChuongTrinh
        [HttpPost]
        public async Task<IActionResult> AddChuongTrinh([FromBody] ChuongTrinh chuongTrinh)
        {
            if (chuongTrinh == null)
                return BadRequest();

            await _chuongTrinhRepository.AddChuongTrinhAsync(chuongTrinh);
            var chuongtrinhMap = _mapper.Map<ChuongTrinh>(chuongTrinh);

            return CreatedAtAction(nameof(GetChuongTrinhById), new { id = chuongtrinhMap.Id }, chuongtrinhMap);
        }

        // PUT api/ChuongTrinh/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChuongTrinh(int id, [FromBody] ChuongTrinh chuongTrinh)
        {
            if (chuongTrinh == null || chuongTrinh.Id != id)
                return BadRequest();

            var existingChuongTrinh = await _chuongTrinhRepository.GetChuongTrinhByIdAsync(id);

            if (existingChuongTrinh == null)
                return NotFound();

            existingChuongTrinh = chuongTrinh;
            var chuongtrinhMap = _mapper.Map<ChuongTrinh>(existingChuongTrinh);

            await _chuongTrinhRepository.UpdateChuongTrinhAsync(chuongtrinhMap);

            return NoContent();
        }

        // DELETE api/ChuongTrinh/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChuongTrinh(int id)
        {
            var chuongTrinh = await _chuongTrinhRepository.GetChuongTrinhByIdAsync(id);

            if (chuongTrinh == null)
                return NotFound();

            await _chuongTrinhRepository.DeleteChuongTrinhAsync(id);

            return NoContent();
        }
    }
}
