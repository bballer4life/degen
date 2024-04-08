namespace FindTheWinner.Models
{
    public readonly struct MyAddress
    {
        public MyAddress(uint number, string name, string address)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(number);
            ArgumentNullException.ThrowIfNullOrEmpty(nameof(name), name);
            ArgumentNullException.ThrowIfNullOrEmpty(nameof(address), address);

            Number = number;
            Name = name;
            Address = address;
        }

        public readonly uint Number;
        public readonly string Name;
        public readonly string Address;
    }
}
