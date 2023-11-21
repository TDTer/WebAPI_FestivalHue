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

        public ChuongTrinhController(IChuongTrinhRepository chuongTrinhRepository)
        {
            _chuongTrinhRepository = chuongTrinhRepository ?? throw new ArgumentNullException(nameof(chuongTrinhRepository));
        }

        // GET api/ChuongTrinh
        [HttpGet]
        public async Task<IActionResult> GetAllChuongTrinhs()
        {
            var chuongTrinhs = await _chuongTrinhRepository.GetAllChuongTrinhsAsync();
            return Ok(chuongTrinhs);
        }

        // GET api/ChuongTrinh/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChuongTrinhById(int id)
        {
            var chuongTrinh = await _chuongTrinhRepository.GetChuongTrinhByIdAsync(id);

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

            return CreatedAtAction(nameof(GetChuongTrinhById), new { id = chuongTrinh.Id }, chuongTrinh);
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

            existingChuongTrinh.ChuongTrinhName = chuongTrinh.ChuongTrinhName;
            existingChuongTrinh.ChuongTrinhContent = chuongTrinh.ChuongTrinhContent;
            // Cập nhật các thuộc tính khác theo cần thiết.

            await _chuongTrinhRepository.UpdateChuongTrinhAsync(existingChuongTrinh);

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
