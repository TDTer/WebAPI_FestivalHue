using AutoMapper;
using FestivalHue2020WebAPI.DTO;
using FestivalHue2020WebAPI.Interfaces;
using FestivalHue2020WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestivalHue2020WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LichDienController : ControllerBase
    {
        private readonly ILichDienRepository _lichDienRepository;
        private readonly IMapper _mapper;

        public LichDienController(ILichDienRepository lichDienRepository, IMapper mapper)
        {
            _lichDienRepository = lichDienRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<LichDienDTO>>> GetAllLichDien()
        {
            var lichDiens = await _lichDienRepository.GetAllLichDienAsync();
            var lichDienDTOs = _mapper.Map<List<LichDienDTO>>(lichDiens);

            return Ok(lichDienDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LichDienDTO>> GetLichDienById(int id)
        {
            var lichDien = await _lichDienRepository.GetLichDienByIdAsync(id);

            if (lichDien == null)
            {
                return NotFound();
            }

            var lichDienDTO = _mapper.Map<LichDienDTO>(lichDien);

            return Ok(lichDienDTO);
        }

        [HttpGet("bydate/{day}")]
        public async Task<ActionResult<LichDienDTO>> GetLichDienByDate(DateTime day)
        {
            var lichDien = await _lichDienRepository.GetLichDienByDateAsync(day);

            if (lichDien == null)
            {
                return NotFound();
            }

            var lichDienDTO = _mapper.Map<LichDienDTO>(lichDien);

            return Ok(lichDienDTO);
        }

        [HttpPost]
        public async Task<ActionResult<LichDienDTO>> AddLichDien(LichDienDTO lichDienDTO)
        {
            var lichDien = _mapper.Map<LichDien>(lichDienDTO);

            await _lichDienRepository.AddLichDienhAsync(lichDien);

            // Mapping lại để có thông tin mới nhất sau khi thêm vào database
            lichDienDTO = _mapper.Map<LichDienDTO>(lichDien);

            return CreatedAtAction(nameof(GetLichDienById), new { id = lichDienDTO.Id }, lichDienDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLichDien(int id, LichDienDTO lichDienDTO)
        {
            if (id != lichDienDTO.Id)
            {
                return BadRequest();
            }

            var existingLichDien = await _lichDienRepository.GetLichDienByIdAsync(id);

            if (existingLichDien == null)
            {
                return NotFound();
            }

            // Sử dụng ReverseMap để thực hiện mapping ngược lại
            _mapper.Map(lichDienDTO, existingLichDien);

            await _lichDienRepository.UpdateLichDienAsync(existingLichDien);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLichDien(int id)
        {
            var existingLichDien = await _lichDienRepository.GetLichDienByIdAsync(id);

            if (existingLichDien == null)
            {
                return NotFound();
            }

            await _lichDienRepository.DeleteLichDienAsync(id);

            return NoContent();
        }
    }
}
