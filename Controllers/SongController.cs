using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassettica.Models.Library;
using Cassettica.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cassettica.Controllers
{
    [Route("music/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ILogger<SongController> _logger;
        private readonly IMusicLibrary _musicLibrary;

        public SongController(ILogger<SongController> logger, IMusicLibrary musicLibrary)
        {
            _logger = logger;
            _musicLibrary = musicLibrary;
        }

        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return _musicLibrary.Songs.Where(s => s.IsActive);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Song song = _musicLibrary.Songs.FirstOrDefault(s => s.IsActive && s.Guid.Equals(id, StringComparison.CurrentCultureIgnoreCase));
            if (song == null)
            {
                return NotFound();
            }
            return PhysicalFile(song.Path, "application/octet-stream", enableRangeProcessing: true);
        }
    }
}