using FindTheWinner.Models;
using Newtonsoft.Json;

namespace FindTheWinner
{
    public sealed class WinnerAddressFetcher
    {
        private const string RequestUri = "https://vmwppqa4er.us-east-1.awsapprunner.com/api/project/getProjectWinnersForTransparency";

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
            HttpResponseMessage response = await client
                .GetAsync(RequestUri);
            return response;
        }

        private sealed record TheirResponse
        {
            public string Logo { get; set; }
            public string Title { get; set; }
            public string Symbol { get; set; }
            public string[] Winners { get; set; }
            public int TotalParticipants { get; set; }
            public string ProofUrl { get; set; }
            public string Roi { get; set; }
            public bool SelectedForTransparency { get; set; }
        }
    }
}