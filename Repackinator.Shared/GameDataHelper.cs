﻿using Newtonsoft.Json;

namespace Repackinator.Shared
{
    public static class GameDataHelper
    {
        public static GameData[]? LoadGameData(string path)
        {
            var gameDataJson = File.ReadAllText(path);
            var result = JsonConvert.DeserializeObject<GameData[]>(gameDataJson);
            return result;
        }

        public static GameData[]? LoadGameData()
        {
            var applicationPath = Utility.GetApplicationPath();
            if (applicationPath == null)
            {
                return null;
            }

            var repackListPath = Path.Combine(applicationPath, "RepackList.json");
            if (!File.Exists(repackListPath))
            {
                return null;
            }

            return LoadGameData(repackListPath);
        }

        public static void SaveGameData(string path, GameData[]? gameData)
        {
            if (gameData == null)
            {
                return;
            }

            var result = JsonConvert.SerializeObject(gameData);
            File.WriteAllText(path, result);
        }

        public static void SaveGameData(GameData[]? gameData)
        {
            var applicationPath = Utility.GetApplicationPath();
            if (applicationPath == null)
            {
                return;
            }

            var repackListPath = Path.Combine(applicationPath, "RepackList.json");
            SaveGameData(repackListPath, gameData);
        }
    }
}