using MedGame.GameLogic;
using MedGame.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MedGame.Services
{
    public static class FileHandler
    {
        public static void SaveToFile()
        {
            Game.Player.ListDatesInRowString = JsonConvert.SerializeObject(Game.Player.ListDatesInRow);
            string json = JsonConvert.SerializeObject(Game.Player);

            File.WriteAllText("player.txt", json);
        }

        public static void LoadFromFile()
        {
            string jsonPlayer = File.ReadAllText("player.txt");
            Game.Player = JsonConvert.DeserializeObject<Player>(jsonPlayer);
            Game.Player.ListDatesInRow = JsonConvert.DeserializeObject<List<DateTime>>(Game.Player.ListDatesInRowString);
        }
    }
}