using JDNowTop.JDNowApiWrapper.Models;
using JDNowTop.JDNowApiWrapper.Utils;

namespace JDNowTop.JDNowApiWrapper
{
    public static class JDNowApi
    {
        public static async Task<IEnumerable<SongInfo>> GetPublishedSongsAsync()
        {
            string? songs = await ApiDataRequestor.GetPublishedSongsAsync();
            var songList = ApiDataParser.ParsePublishedSongs(songs);
            return songList;
        }

        public static async Task<int> GetSocialDataAsync(string _mapName)
        {
            string? socialData = await ApiDataRequestor.GetSocialDataAsync(_mapName);
            var parsedData = ApiDataParser.ParseSocialData(socialData);
            return parsedData;
        }

        public static async Task<SongInfo?> GetSongDataAsync(SongInfo _song)
        {
            string? songData = await ApiDataRequestor.GetSongDataAsync(_song.BaseURL + $"/{_song.MapName}.json");
            var parsedData = ApiDataParser.ParseSongData(songData);
            return parsedData;
        }
    }
}
