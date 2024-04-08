using FindTheWinner.Models;

namespace FindTheWinner
{
    public static class MyAddressExtension
    {
        public static IEnumerable<MyWinner> GetMyWinners
            (this IEnumerable<MyAddress> myAddresses, IEnumerable<WinnerAddress> winners)
        {
            var groups = winners.GroupBy(
                    keySelector: winner => winner.Address,
                    comparer: StringComparer.InvariantCultureIgnoreCase)
                .ToDictionary(
                    winnerGroup => winnerGroup.Key,
                    winnerGroup => winnerGroup.ToArray(),
                    StringComparer.InvariantCultureIgnoreCase
                );

            foreach (var address in myAddresses)
            {
                if (groups.TryGetValue(key: address.Address, out var groupWinners))
                {
                    foreach (var winner in groupWinners)
                    {
                        yield return new MyWinner
                        (
                            number: address.Number,
                            name: address.Name,
                            address: address.Address,
                            title: winner.Title
                        );
                    }
                }
            }
        }
    }
}
