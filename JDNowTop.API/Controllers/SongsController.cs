using AutoMapper;
using JDNowTop.Data.Models;
using JDNowTop.Data.Models.DTO;
using JDNowTop.Logic.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JDNowTop.API.Controllers
{
    [Route("api/songs")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;

        public SongsController(ISongService songService, IPositionService positionService, IMapper mapper)
        {
            _songService = songService;
            _positionService = positionService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetSongs()
        {
            var songs = await _songService.GetAllAsync();
            return Ok(songs.Select(s => _mapper.Map<Song, SongDto>(s)));
        }

        [HttpGet("{mapName}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetSong([FromRoute] string mapName)
        {
            var song = await _songService.GetByMapNameAsync(mapName);

            if (song == null) return NotFound();
            return Ok(_mapper.Map<Song, SongDto>(song));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateSong([FromBody] Song song)
        {
            var attachedEntity = await _songService.CreateAsync(song);
            if (attachedEntity != null) return Ok(attachedEntity);
            else return BadRequest();
        }

        [HttpPut("{mapName}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateSong([FromBody] Song song, [FromRoute] string mapName)
        {
            if (song.MapName != mapName) return BadRequest();

            var updatedSong = await _songService.UpdateAsync(song);
            if (updatedSong != null) return Ok(updatedSong);
            else return NotFound();
        }

        [HttpDelete("{mapName}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSong([FromRoute] string mapName)
        {
            if (await _songService.DeleteByMapNameAsync(mapName)) return Ok();
            else { return NotFound(); }
        }


    }
}
