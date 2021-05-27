using GroceryStore.Application.Customers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace GroceryStore.Application
{
    [Serializable]
    public class DataStore : IDataStore
    {
        private Database _database;
        public IList<Customer> Customers => _database.Customers;

        private string _dataFilePath { get; set; }
        public DataStore()
        {
            _dataFilePath = "database.json";
            _database = new Database();
        }
        public DataStore(string dataFilePath)
        {
            _dataFilePath = dataFilePath;
            _database = new Database();
        }
        public void LoadData()
        {
            if (!string.IsNullOrEmpty(_dataFilePath) && File.Exists(_dataFilePath))
            {
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                _database = JsonSerializer.Deserialize<Database>(File.ReadAllText(_dataFilePath),jsonSerializerOptions);
            }
        }
        public void SaveChanges()
        {
            if (!string.IsNullOrEmpty(_dataFilePath) && File.Exists(_dataFilePath))
            {
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var fileStream = File.Create(_dataFilePath);
                JsonSerializer.Serialize(new Utf8JsonWriter(fileStream, new JsonWriterOptions { Indented = true}), _database, jsonSerializerOptions);
                fileStream.Flush();
                fileStream.Close();
                fileStream.Dispose();
            }
        }
    }
}
