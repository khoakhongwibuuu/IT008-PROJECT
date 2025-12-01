using System;
using System.IO;
using System.Text.Json;
using System.Drawing;
namespace WordleClient.libraries.StateFrom
{
    internal class ProfileState
    {
        // User profile fields
        public string Nickname { get; set; } = "Player1";
        public string? AvatarPath { get; set; } = null;
        // JSON file to store profile data
        private static readonly string saveFile = "profile.json";
        public static ProfileState? Current { get; private set; } = new ProfileState();
        // Cached options for JSON serialization
        private static readonly JsonSerializerOptions jsonOptions = new()
        {
            WriteIndented = true
        };
        // Load profile from JSON file (deserialize)
        public static void Load()
        {
            if (File.Exists(saveFile))
            {
                string json = File.ReadAllText(saveFile);
                Current = JsonSerializer.Deserialize<ProfileState>(json,jsonOptions) ?? new ProfileState();
            }
            else
            {
                Current = new ProfileState(); 
            }
        }
        // Save profile to JSON file (serialize)
        public static void Save()
        {
            string json = JsonSerializer.Serialize(Current, jsonOptions);
            File.WriteAllText(saveFile, json);
        }
        // Get avatar image based on AvatarPath
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
            return Properties.Resources.Avatar9; 
        }
    }
}
