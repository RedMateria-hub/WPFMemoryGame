using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MemoryGame.Models;

namespace MemoryGame.Services
{
    public static class UserStorageService
    {
        private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "users.json");

        public static void SaveUsers(List<User> users)
        {
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public static List<User> LoadUsers()
        {
            if (!File.Exists(FilePath))
                return new List<User>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }
    }
}
