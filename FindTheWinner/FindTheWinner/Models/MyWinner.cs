namespace FindTheWinner.Models
{
    public readonly struct MyWinner
    {
        public readonly uint Number;
        public readonly string Name;
        public readonly string Address;
        public readonly string Title;

        public MyWinner(uint number, string name, string address, string title)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value: number, paramName: nameof(number));
            ArgumentException.ThrowIfNullOrWhiteSpace(argument: name, paramName: nameof(name));
            ArgumentException.ThrowIfNullOrWhiteSpace(argument: address, paramName: nameof(address));
            ArgumentException.ThrowIfNullOrWhiteSpace(argument: title, paramName: nameof(title));

            Number = number;
            Name = name;
            Address = address;
            Title = title;
        }
    }
}
