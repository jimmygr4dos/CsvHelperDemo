// Comma Separated Values (CSV) Demo
// 1,Tim,Corey,555-1212

using CsvDemo;
using CsvHelper;
using System.Globalization;

//string inputFile = @"~\files\customers-1000.csv";
//string outputFile = @"~\files\filtered-customers.csv";

//string inputFile = @"C:\Users\jimmy\source\repos\IntroToCsvHelper\CsvDemo\files\customers-100.csv";
//string outputFile = @"C:\Users\jimmy\source\repos\IntroToCsvHelper\CsvDemo\files\filtered-customers.csv";
string inputFile = @"C:\Users\jimmy\source\repos\IntroToCsvHelper\CsvDemo\files\organizations-100000.csv";
string outputFile = @"C:\Users\jimmy\source\repos\IntroToCsvHelper\CsvDemo\files\filtered-organizations.csv";

//List<CustomerModel> outputRecords = new();
List<OrganizationModel> outputRecords = new();

using var reader = new StreamReader(inputFile);
using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
int i = 0;

var records = csv.GetRecords<OrganizationModel>();

foreach (var record in records)
{
    if (record.Name.Contains('-'))
    {
        outputRecords.Add(record);
    }
    Console.WriteLine(record.Index + " " + record.Name);
    i++;
}

Console.WriteLine($"Number of records: {outputRecords.Count}");

using var writer = new StreamWriter(outputFile);
using var csvOut = new CsvWriter(writer, CultureInfo.InvariantCulture);

csvOut.WriteRecords(outputRecords);

Console.ReadLine();