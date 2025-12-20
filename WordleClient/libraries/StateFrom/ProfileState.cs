using System;
using System.IO;
using System.Text.Json;
using System.Drawing;
namespace WordleClient.libraries.StateFrom
{
    internal class ProfileState
    {
        // User profile fields
        public string Nickname { get; set; } = Environment.UserName;
        public string? AvatarPath { get; set; } = null;
        private static readonly string saveFile = "profile.json";
        private static readonly string configFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WordleClient", "userdata");
        public static ProfileState? Current { get; private set; } = new ProfileState();
        
        // Cached options for JSON serialization
        private static readonly JsonSerializerOptions jsonOptions = new()
        {
            WriteIndented = true
        };

        public static void Load()
        {
            string filepath = Path.Combine(configFolder, saveFile);
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                Current = JsonSerializer.Deserialize<ProfileState>(json, jsonOptions) ?? new ProfileState();
            }
            else
            {
                Current = new ProfileState();
            }
        }
        public static void Save()
        {
            if (!Directory.Exists(configFolder))
                Directory.CreateDirectory(configFolder);
            
            string filePath = Path.Combine(configFolder, saveFile);
            string json = JsonSerializer.Serialize(Current, jsonOptions);
            File.WriteAllText(filePath, json);
        }
        public static Image GetAvatar()
        {
            if (Current != null && !string.IsNullOrEmpty(Current.AvatarPath))
            {
                if (File.Exists(Current.AvatarPath))
                {
                    return Image.FromFile(Current.AvatarPath);
                }
                if (Current.AvatarPath is not null && Properties.Resources.ResourceManager.GetObject(Current.AvatarPath) is Image img)
                {
                    return img;
                }
            }
            return Properties.Resources.Avatar0;
        }
        public static String GetPlayername()
        {
            if (ProfileState.Current == null) return String.Empty;
            return ProfileState.Current.Nickname;
        }
    }
}
