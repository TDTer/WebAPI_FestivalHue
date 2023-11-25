using AutoMapper;
using FestivalHue2020WebAPI.DTO;
using FestivalHue2020WebAPI.Interfaces;
using FestivalHue2020WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FestivalHue2020WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeController : ControllerBase
    {
        private readonly IVeReponsitory _veRepository;
        private readonly IMapper _mapper;
      

        public VeController(IVeReponsitory veRepository, IMapper mapper)
        {
            _veRepository = veRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<VeDTO>>> GetAllVe()
        {
            var ves = await _veRepository.GetAllVeAsync();
            var veDTOs = _mapper.Map<List<VeDTO>>(ves);

            return Ok(veDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeDTO>> GetVeById(int id)
        {
            var ve = await _veRepository.GetVeByIdAsync(id);

            if (ve == null)
            {
                return NotFound();
            }

            var veDTO = _mapper.Map<VeDTO>(ve);

            return Ok(veDTO);
        }

        [HttpPost]
        public async Task<ActionResult<VeDTO>> AddVe(VeDTO veDTO)
        {
            var ve = _mapper.Map<Ve>(veDTO);

            await _veRepository.AddVeAsync(ve);

            // Mapping lại để có thông tin mới nhất sau khi thêm vào database
            veDTO = _mapper.Map<VeDTO>(ve);

            return CreatedAtAction(nameof(GetVeById), new { id = veDTO.Id }, veDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVe(int id, VeDTO veDTO)
        {
            if (id != veDTO.Id)
            {
                return BadRequest();
            }

            var existingVe = await _veRepository.GetVeByIdAsync(id);

            if (existingVe == null)
            {
                return NotFound();
            }

            // Sử dụng ReverseMap để thực hiện mapping ngược lại
            _mapper.Map(veDTO, existingVe);

            await _veRepository.UpdateVeAsync(existingVe);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVe(int id)
        {
            var existingVe = await _veRepository.GetVeByIdAsync(id);

            if (existingVe == null)
            {
                return NotFound();
            }

            await _veRepository.DeleteVeAsync(id);

            return NoContent();
        }
    }
}
