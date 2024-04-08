using FindTheWinner.Extras;

namespace FindTheWinner.Cmd
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var path = args[0];

            if (!File.Exists(path))
                throw new Exception($"Expected CSV file is missing: {path}");

            Console.WriteLine(Phrases.Greetings.Random());
            Console.WriteLine(Phrases.FetchingWinners.Random());
            var winners = await WinnerAddressFetcher.GetProjectWinnersForTransparencyAsync();

            Console.WriteLine(Phrases.FetchingCsv.Random());
            var myAddresses = path.ReadMyAddresses();
            var myWinners = myAddresses.GetMyWinners(winners).ToArray();

            if (myWinners.Any())
            {
                Console.WriteLine(Phrases.SomethingFound.Random());
                var groups = myWinners.GroupBy(x => x.Title).OrderBy(x => x.Key).ToArray();
                foreach (var group in groups)
                {
                    await Console.Out.WriteLineAsync("--------------");
                    Console.WriteLine($"Title: {group.Key}");
                    await Console.Out.WriteLineAsync("--------------");
                    foreach (var address in group)
                    {
                        Console.WriteLine($"#{address.Number}, {address.Name}, address: {address.Address}");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine(Phrases.NothingFound.Random());
            }
            Console.WriteLine(Phrases.Goodbyes.Random());
        }
    }
}
