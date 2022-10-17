namespace JDNowTop.JDNowApiWrapper.Utils
{
    internal static class ApiDataRequestor
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<string?> GetPublishedSongsAsync()
        {
            var response = await _httpClient.GetAsync(Constants.SongsUrl);

            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string?> GetSocialDataAsync(string _map)
        {
            HttpResponseMessage response;

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Constants.SocialDataUrl + $"?song={_map}"))
            {
                request.Headers.Add(Constants.SocialDataPlatformHeader.Item1, Constants.SocialDataPlatformHeader.Item2);
                response = await _httpClient.SendAsync(request);
            }

            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string?> GetSongDataAsync(string _baseUrl)
        {
            var response = await _httpClient.GetAsync(_baseUrl);

            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadAsStringAsync();
        }
    }
}
