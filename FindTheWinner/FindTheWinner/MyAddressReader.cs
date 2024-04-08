using CsvHelper;
using CsvHelper.Configuration;
using FindTheWinner.Models;
using System.Globalization;

namespace FindTheWinner
{
    public static class MyAddressReader
    {
        public static MyAddress[] ReadMyAddresses(this string csvFilePath)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader: reader, configuration: csvConfig))
            {
                var parsedRecords = csv.GetRecords<MyAddressDto>().ToArray();
                var myaddresses = parsedRecords.Select(x => new MyAddress(x.Number, x.Name, x.Address))
                    .ToArray();
                return myaddresses;
            }
        }

        private sealed record MyAddressDto
        {
            public uint Number { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
        }
    }
}