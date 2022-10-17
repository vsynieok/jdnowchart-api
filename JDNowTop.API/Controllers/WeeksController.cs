using AutoMapper;
using JDNowTop.Data.Models;
using JDNowTop.Data.Models.DTO;
using JDNowTop.Logic.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JDNowTop.API.Controllers
{
    [Route("api/weeks")]
    [ApiController]
    public class WeeksController : ControllerBase
    {
        private readonly IWeekService _weekService;
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;

        public WeeksController(IWeekService weekService, IPositionService positionService)
        {
            _weekService = weekService;
            _positionService = positionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWeeks()
        {
            return Ok((await _weekService.GetAllAsync()).Select(w => _mapper.Map<Week, WeekDto>(w)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWeek([FromRoute] int id)
        {
            var dbWeek = await _weekService.GetAsync(id);
            if (dbWeek == null) return NotFound();

            var week = _mapper.Map<Week, WeekDto>(dbWeek);
            return Ok(week);
        }

        [HttpPost]
        public async Task<IActionResult> NewWeek([FromBody] WeekDto _week)
        {
            var entity = _mapper.Map<WeekDto, Week>(_week);
            var createdEntity = await _weekService.CreateAsync(entity);

            if (createdEntity == null) return BadRequest();
            else return Ok(createdEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeek([FromBody] WeekDto _week, [FromRoute] int id)
        {
            var entity = _mapper.Map<WeekDto, Week>(_week);
            var updatedEntity = await _weekService.UpdateAsync(entity, id);

            if (updatedEntity == null) return NotFound();
            else
            {
                var result = _mapper.Map<Week, WeekDto>(updatedEntity);
                return Ok(result);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeek([FromRoute] int id)
        {
            if (!await _weekService.DeleteAsync(id)) return NotFound();
            else return Ok();
        }

        [HttpPost("{id}/positions")]
        public async Task<IActionResult> AddPositionByWeek([FromRoute] int id, [FromBody] Position position)
        {
            var createdEntity = await _positionService.CreateByWeekAsync(id, position);

            if (createdEntity == null) return BadRequest();
            else return Ok(createdEntity);
        }

        [HttpPut("{id}/positions/{posId}")]
        public async Task<IActionResult> UpdatePositionByWeek([FromRoute] int id, [FromRoute] int posId, [FromBody] Position position)
        {
            if (position.Id != posId) return BadRequest();

            var updatedEntity = await _positionService.UpdateByWeekAsync(id, position);

            if (updatedEntity == null) return NotFound();
            else return Ok(updatedEntity);
        }
    }
}
