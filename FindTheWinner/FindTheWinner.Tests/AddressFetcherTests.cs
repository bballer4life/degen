using FluentAssertions;
using Xunit;

namespace FindTheWinner.Tests
{
    public sealed class AddressFetcherTests
    {
        [Fact]
        public async Task Ensure_Fetcher_ReturnsAddresses()
        {
            var addresses = await WinnerAddressFetcher.GetProjectWinnersForTransparencyAsync();
            addresses.Should().NotBeEmpty();

            foreach (var address in addresses)
            {
                await Console.Out.WriteLineAsync($"{address.Title}:{address.Address}");
            }
        }
    }
}
