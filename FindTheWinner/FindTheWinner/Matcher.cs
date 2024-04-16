using FindTheWinner.Models;

namespace FindTheWinner
{
    public static class MyAddressExtension
    {
        public static IEnumerable<MyWinner> GetMyWinners
            (this IEnumerable<MyAddress> myAddresses, IEnumerable<WinnerAddress> winners)
        {
            var myWinners = from myAddress in myAddresses
                        join winner in winners
                        on myAddress.Address.ToUpper() equals winner.Address.ToUpper()
                        select new MyWinner
                    (
                        number: myAddress.Number,
                        name: myAddress.Name,
                        address: myAddress.Address,
                        title: winner.Title
                    );

            return myWinners.ToArray();
        }
    }
}
