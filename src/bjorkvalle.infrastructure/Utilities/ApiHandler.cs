namespace bjorkvalle.infrastructure.Utilities
{
    public class ApiHandler
    {
        private readonly HttpClient http;

        public ApiHandler(HttpClient http)
        {
            this.http = http;
        }

        public async Task<T> GetData<T>(string url)
        {
            var response = await http.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>();
                return result;
            }
            else
                throw new Exception(response.ReasonPhrase);
        }

        public async Task<bool> PostDataAsync<T>(string url, T body)
        {
            var response = await http.PostAsJsonAsync(url, body);

            if (response.IsSuccessStatusCode)
                return true;
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }

        public async Task<bool> Delete(string url)
        {
            var response = await http.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
                return true;
            else
                throw new Exception(response.ReasonPhrase);
        }

        public async Task<bool> Delete<T>(string url, T data)
        {
            var response = await http.DeleteAsJsonAsync(url, data);

            if (response.IsSuccessStatusCode)
                return true;
            else
                throw new Exception(response.ReasonPhrase);
        }
    }
}
