using AutoMapper;
using FestivalHue2020WebAPI.DTO;
using FestivalHue2020WebAPI.Interfaces;
using FestivalHue2020WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestivalHue2020WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiaDiemController : ControllerBase
    {
        private readonly IDiaDiemRepository _diaDiemRepository;
        private readonly IMapper _mapper;

        public DiaDiemController(IDiaDiemRepository diaDiemRepository, IMapper mapper)
        {
            _diaDiemRepository = diaDiemRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<DiaDiemDTO>>> GetAllDiaDiem()
        {
            var diaDiems = await _diaDiemRepository.GetAllDiaDiemAsync();
            var diaDiemDTOs = _mapper.Map<List<DiaDiemDTO>>(diaDiems);

            return Ok(diaDiemDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiaDiemDTO>> GetDiaDiemById(int id)
        {
            var diaDiem = await _diaDiemRepository.GetDiaDiemByIdAsync(id);

            if (diaDiem == null)
            {
                return NotFound();
            }

            var diaDiemDTO = _mapper.Map<DiaDiemDTO>(diaDiem);

            return Ok(diaDiemDTO);
        }

        [HttpPost]
        public async Task<ActionResult<DiaDiemDTO>> AddDiaDiem(DiaDiemDTO diaDiemDTO)
        {
            var diaDiem = _mapper.Map<DiaDiem>(diaDiemDTO);

            await _diaDiemRepository.AddDiaDiemAsync(diaDiem);

            // Mapping lại để có thông tin mới nhất sau khi thêm vào database
            diaDiemDTO = _mapper.Map<DiaDiemDTO>(diaDiem);

            return CreatedAtAction(nameof(GetDiaDiemById), new { id = diaDiemDTO.Id }, diaDiemDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDiaDiem(int id, DiaDiemDTO diaDiemDTO)
        {
            if (id != diaDiemDTO.Id)
            {
                return BadRequest();
            }

            var existingDiaDiem = await _diaDiemRepository.GetDiaDiemByIdAsync(id);

            if (existingDiaDiem == null)
            {
                return NotFound();
            }

            _mapper.Map(diaDiemDTO, existingDiaDiem);

            await _diaDiemRepository.UpdateDiaDiemAsync(existingDiaDiem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDiaDiem(int id)
        {
            var existingDiaDiem = await _diaDiemRepository.GetDiaDiemByIdAsync(id);

            if (existingDiaDiem == null)
            {
                return NotFound();
            }

            await _diaDiemRepository.DeleteDiaDiemAsync(id);

            return NoContent();
        }
    }
}
