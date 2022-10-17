using JDNowTop.Data.Models;
using JDNowTop.Data.Repositories.Abstractions;
using JDNowTop.JDNowApiWrapper;
using JDNowTop.Logic.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDNowTop.Logic.Operations
{
    public class DatabaseSeeder
    {
        private readonly ISongService _songService;
        private readonly IWeekService _weekService;
        private readonly IPositionService _positionService;

        public DatabaseSeeder(ISongService songService, IWeekService weekService, IPositionService positionService)
        {
            _songService = songService;
            _weekService = weekService;
            _positionService = positionService;
        }

        public async Task SeedSongs()
        {
            var songs = await JDNowApi.GetPublishedSongsAsync();
            foreach (var song in songs)
            {
                var songData = await JDNowApi.GetSongDataAsync(song);
                var socialData = await JDNowApi.GetSocialDataAsync(song.MapName);

                Song songEntity = new Song()
                {
                    MapName = song.MapName,
                    TotalPlays = socialData,
                    Mode = song.Coaches,
                    GameVersion = songData.Value.GameVersion
                };

                var createdEntity = await _songService.CreateAsync(songEntity);
                if (createdEntity == null)
                {
                    await _songService.UpdateAsync(songEntity);
                }
            }
        }

        public async Task SeedPositions()
        {
            var week = await _weekService.CreateAsync(new Week()
            {
                UpdatedAt = DateTime.Now
            });

            if (week == null) return;

            var songs = (await _songService.GetAllAsync()).OrderByDescending(s => s.TotalPlays).ToList();

            for (int idx = 0; idx < songs.Count; idx++)
            {
                var previousPosition = songs[idx].Positions.OrderByDescending(p => p.WeekId).FirstOrDefault();
                var delta = previousPosition != null ? previousPosition.Delta : 0; 
                var position = await _positionService.CreateAsync(new Position()
                {
                    WeekId = week.Id,
                    Pos = idx + 1,
                    Delta = (await JDNowApi.GetSocialDataAsync(songs[idx].MapName)) - songs[idx].TotalPlays - delta,
                    MapName = songs[idx].MapName
                });
            }
        }
    }
}
