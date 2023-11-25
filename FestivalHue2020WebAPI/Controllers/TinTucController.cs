using AutoMapper;
using FestivalHue2020WebAPI.DTO;
using FestivalHue2020WebAPI.Interfaces;
using FestivalHue2020WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestivalHue2020WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TinTucController : ControllerBase
    {
        private readonly ITinTucRepository _tinTucRepository;
        private readonly IMapper _mapper;

        public TinTucController(ITinTucRepository tinTucRepository, IMapper mapper)
        {
            _tinTucRepository = tinTucRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TinTucDTO>>> GetAllTinTuc()
        {
            var tinTucs = await _tinTucRepository.GetAllTinTucAsync();
            var tinTucDTOs = _mapper.Map<List<TinTucDTO>>(tinTucs);

            return Ok(tinTucDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TinTucDTO>> GetTinTucById(int id)
        {
            var tinTuc = await _tinTucRepository.GetTinTucByIdAsync(id);

            if (tinTuc == null)
            {
                return NotFound();
            }

            var tinTucDTO = _mapper.Map<TinTucDTO>(tinTuc);

            return Ok(tinTucDTO);
        }

        [HttpPost]
        public async Task<ActionResult<TinTucDTO>> AddTinTuc(TinTucDTO tinTucDTO)
        {
            var tinTuc = _mapper.Map<TinTuc>(tinTucDTO);

            await _tinTucRepository.AddTinTucAsync(tinTuc);

            // Mapping lại để có thông tin mới nhất sau khi thêm vào database
            tinTucDTO = _mapper.Map<TinTucDTO>(tinTuc);

            return CreatedAtAction(nameof(GetTinTucById), new { id = tinTucDTO.Id }, tinTucDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTinTuc(int id, TinTucDTO tinTucDTO)
        {
            if (id != tinTucDTO.Id)
            {
                return BadRequest();
            }

            var existingTinTuc = await _tinTucRepository.GetTinTucByIdAsync(id);

            if (existingTinTuc == null)
            {
                return NotFound();
            }

            // Sử dụng ReverseMap để thực hiện mapping ngược lại
            _mapper.Map(tinTucDTO, existingTinTuc);

            await _tinTucRepository.UpdateTinTucAsync(existingTinTuc);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTinTuc(int id)
        {
            var existingTinTuc = await _tinTucRepository.GetTinTucByIdAsync(id);

            if (existingTinTuc == null)
            {
                return NotFound();
            }

            await _tinTucRepository.DeleteTinTucAsync(id);

            return NoContent();
        }
    }
}
