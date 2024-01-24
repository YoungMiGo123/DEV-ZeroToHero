namespace ZeroToHero.Interfaces.Console
{
    using System;
    using System.IO;
    public class DataStorageInterfaces
    {
        public interface IDataStorage
        {
            void SaveData(string fileName, string data);
            string ReadData(string fileName);
        }

        public class CsvDataStorage : IDataStorage
        {
            public void SaveData(string fileName, string data)
            {
                try
                {
                    File.WriteAllText(fileName, data);
                    Console.WriteLine($"Data saved to CSV file: {fileName}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving data to CSV file: {ex.Message}");
                }
            }

            public string ReadData(string fileName)
            {
                try
                {
                    string data = File.ReadAllText(fileName);
                    Console.WriteLine($"Data read from CSV file: {fileName}");
                    return data;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading data from CSV file: {ex.Message}");
                    return null;
                }
            }
        }

        public class JsonDataStorage : IDataStorage
        {
            public void SaveData(string fileName, string data)
            {
                try
                {
                    File.WriteAllText(fileName, data);
                    Console.WriteLine($"Data saved to JSON file: {fileName}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving data to JSON file: {ex.Message}");
                }
            }

            public string ReadData(string fileName)
            {
                try
                {
                    string data = File.ReadAllText(fileName);
                    Console.WriteLine($"Data read from JSON file: {fileName}");
                    return data;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading data from JSON file: {ex.Message}");
                    return null;
                }
            }
        }

        public static void BuildStorageExample()
        {
            // Example with CsvDataStorage
            IDataStorage dataStorage = new CsvDataStorage();
            string csvFileName = "data.csv";
            string csvData = "1,John,Doe\n2,Jane,Smith";

            dataStorage.SaveData(csvFileName, csvData);
            string readCsvData = dataStorage.ReadData(csvFileName);
            Console.WriteLine($"CSV Data Read:\n{readCsvData}");

            Console.WriteLine();

            // Example with JsonDataStorage
            dataStorage = new JsonDataStorage();
            string jsonFileName = "data.json";
            string jsonData = "{ \"id\": 1, \"name\": \"Alice\" }";

            dataStorage.SaveData(jsonFileName, jsonData);
            string readJsonData = dataStorage.ReadData(jsonFileName);
            Console.WriteLine($"JSON Data Read:\n{readJsonData}");
        }

    }
}
