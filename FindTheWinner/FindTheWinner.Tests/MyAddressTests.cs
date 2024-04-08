using FluentAssertions;
using Xunit;

namespace FindTheWinner.Tests
{
    public sealed class MyAddressTests
    {
        [Fact]
        public void CanReadFromFile()
        {
            var path = @"Assets\MyAddresses.csv";
            var addresses = MyAddressReader.ReadMyAddresses(path);
            addresses.Should().NotBeEmpty();

            foreach (var address in addresses)
            {
                Console.WriteLine($"{address.Number} {address.Name} {address.Address}");
            }
        }
    }
}
