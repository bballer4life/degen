using FindTheWinner.Models;
using Newtonsoft.Json;

namespace FindTheWinner
{
    public sealed class WinnerAddressFetcher
    {
        public static async Task<WinnerAddress[]> GetProjectWinnersForTransparencyAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await DoRequest(client);

                // Check if the response is successful
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"request failed with {response.StatusCode}");

                string responseBody = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<TheirResponse[]>(responseBody);
                var addresses = responseData.SelectMany(
                    group => group.Winners
                        .Select(winnerAddress => new WinnerAddress(title: group.Title, address: winnerAddress))
                    )
                    .ToArray();

                return addresses;
            }
        }

        private static async Task<HttpResponseMessage> DoRequest(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9,uk-UA;q=0.8,uk;q=0.7");
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("Origin", "https://launch.apeterminal.io");
            client.DefaultRequestHeaders.Add("Referer", "https://launch.apeterminal.io/");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "cross-site");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/123.0.0.0 Safari/537.36");
            client.DefaultRequestHeaders.Add("sec-ch-ua", "\"Google Chrome\";v=\"123\", \"Not:A-Brand\";v=\"8\", \"Chromium\";v=\"123\"");
            client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
            client.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");

            HttpResponseMessage response = await client.GetAsync("https://vmwppqa4er.us-east-1.awsapprunner.com/api/project/getProjectWinnersForTransparency");
            return response;
        }

        private sealed record TheirResponse
        {
            public string Logo { get; set; }
            public string Title { get; set; }
            public string Symbol { get; set; }
            public string[] Winners { get; set; }
            public int TotalParticipants { get; set; }
            public string ProofUri { get; set; }
            public string Roi { get; set; }
            public bool SelectedForTransparency { get; set; }
        }
    }
}