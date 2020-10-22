using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Users.Domain;

namespace Users.StorageAccess
{
    public static class DataFile
    {
        public static async Task<ReadOnlyCollection<T>> ReadFromFileAsync<T>() where T : new()
        {
            T o = new T();
            return o switch
            {
                Address _ => await ReadTypedDataFromFileAsync<T>("Addresses.json"),
                UserRow _ => await ReadTypedDataFromFileAsync<T>("Users.json"),
                Invoice _ => await ReadTypedDataFromFileAsync<T>("Invoices.json"),
                _ => default
            };
        }
        private static async Task<ReadOnlyCollection<T>> ReadTypedDataFromFileAsync<T>(string path) =>
            (TryDeserialize(await ReadStringDataFromFileAsync(path), out List<T> retVal)
                ? retVal
                : new List<T>()).AsReadOnly();

        private static async Task<string> ReadStringDataFromFileAsync(string path)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = $"Users.StorageAccess.{path}";
            await using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
                throw new Exception(
                    $"Resource {resourceName} not found in {assembly.FullName}.  Valid resources are: {string.Join(", ", assembly.GetManifestResourceNames())}.");
            using var reader = new StreamReader(stream);

            string readToEndAsync = await reader.ReadToEndAsync();
            return readToEndAsync;
        }
        private static bool TryDeserialize<T>(string json, out T deserialized)
        {
            try
            {
                deserialized = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            }
            catch
            {
                deserialized = default;
                return false;
            }

            return true;
        }
    }
}