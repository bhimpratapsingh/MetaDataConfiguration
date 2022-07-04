namespace MetaDataConfiguration.Shared.Helpers
{
    public class HttpClientHelper
    {
        private readonly HttpClient _httpClient;
        public HttpClientHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string GetResponse(string url)
        {
            try
            {
                using
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = _httpClient.Send(request);
                var reader = new StreamReader(response.Content.ReadAsStream());
                return reader.ReadToEnd();
            }
            catch (Exception)
            {
                //logger implementation
                return string.Empty;
            }
        }
    }
}