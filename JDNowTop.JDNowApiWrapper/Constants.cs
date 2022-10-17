using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDNowTop.JDNowApiWrapper
{
    internal static class Constants
    {
        public static readonly string SongsUrl = "https://ire-prod-api.justdancenow.com/v1/songs/published";
        public static readonly string SocialDataUrl = "https://ire-prod-jdns.justdancenow.com/getSocialData";
        public static readonly (string, string) SocialDataPlatformHeader = ("X-Platform", "web");
        public static readonly string SongDataParseRegex = @"(?!(.*\())((.|\n)*(?=\)))";
    }
}
