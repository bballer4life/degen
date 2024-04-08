namespace FindTheWinner.Models
{
    public readonly struct WinnerAddress
    {
        public WinnerAddress
            (
                string title,
                string address
            )
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(title);
            ArgumentException.ThrowIfNullOrWhiteSpace(address);

            Title = title;
            Address = address;
        }
        public readonly string Title;
        public readonly string Address;
    }
}