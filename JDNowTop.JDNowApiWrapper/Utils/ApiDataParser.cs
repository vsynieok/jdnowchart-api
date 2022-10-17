using System.Text.RegularExpressions;
using JDNowTop.JDNowApiWrapper.Models;
using Newtonsoft.Json.Linq;

namespace JDNowTop.JDNowApiWrapper.Utils
{
    internal class ApiDataParser
    {
        public static IEnumerable<SongInfo> ParsePublishedSongs(string? songs)
        {
            if (songs == null) return new List<SongInfo>();

            try
            {
                JArray songsArray = JArray.Parse(songs);

                IEnumerable<SongInfo> songList = songsArray
                    .Select(song => new SongInfo {
                        MapName = (string)song["id"],
                        Coaches = (int)song["coaches"],
                        BaseURL = (string)song["base"]
                    });

                return songList;
            }
            catch
            {
                return new List<SongInfo>();
            }
        }

        public static int ParseSocialData(string? _socialData)
        {
            if (_socialData == null) return 0;

            try
            {
                JObject data = JObject.Parse(_socialData);
                return (int)data["data"]["communityStats"][1]["oasisParams"]["[number]"];
            }
            catch
            {
                return 0;
            }
        }

        public static SongInfo? ParseSongData(string? song)
        {
            if (song == null) return null;

            try
            {
                var json = Regex.Match(song, Constants.SongDataParseRegex).Value;

                JObject songInfo = JObject.Parse(json);

                return new SongInfo()
                {
                    GameVersion = (int)songInfo["OriginalJDVersion"]
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
