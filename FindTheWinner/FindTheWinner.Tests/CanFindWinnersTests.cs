using FluentAssertions;
using Xunit;

namespace FindTheWinner.Tests
{
    public sealed class CanFindWinnersTests
    {
        [Fact]
        public async Task WinnerCanBeFound()
        {
            var theirAddresses = await WinnerAddressFetcher.GetProjectWinnersForTransparencyAsync();
            theirAddresses.Should().NotBeEmpty();

            var myAddresses = @"Assets\MyAddressesWithFakeWinners.csv".ReadMyAddresses();
            var winners = myAddresses.GetMyWinners(theirAddresses).ToArray();

            winners.Should().NotBeEmpty().And.HaveCount(2);

            foreach (var address in winners)
            {
                Console.WriteLine($"#{address.Number} {address.Name}\t address: {address.Address} Title: {address.Title}");
            }
        }
    }
}
