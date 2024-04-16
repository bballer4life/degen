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
                var myaddresses = parsedRecords.Select(x 
                    => new MyAddress
                        (
                            uint.Parse(x.Number.Trim()), 
                            x.Name.Trim(), 
                            x.Address.Trim()
                        ))
                    .ToArray();
                return myaddresses;
            }
        }

        private record struct MyAddressDto
            (
                string Number, 
                string Name, 
                string Address
            );
    }
}