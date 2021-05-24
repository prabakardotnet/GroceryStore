﻿using GroceryStore.Application.Customers;
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
        public void PersistData()
        {
            if (!string.IsNullOrEmpty(_dataFilePath) && File.Exists(_dataFilePath))
            {
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                JsonSerializer.Serialize(new Utf8JsonWriter(File.Create(_dataFilePath),new JsonWriterOptions { Indented = true}), _database, jsonSerializerOptions);
            }
        }
    }
}
