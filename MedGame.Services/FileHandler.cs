using MedGame.GameLogic;
using MedGame.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MedGame.Services
{
    public static class FileHandler
    {
        public static async Task SavePlayerToFile(Player player, string userName)
        {
            await Task.Run(() =>
            {
                try
                {
                    player.ListDatesInRowString = JsonConvert.SerializeObject(player.ListDatesInRow);
                    string json = JsonConvert.SerializeObject(player);

                    File.WriteAllText(userName + ".txt", json);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Could not save player + {ex}");
                }
            });
        }

        public async static Task<Player> LoadPlayerFromFile(string userName)
        {
            return await Task.Run(() =>
              {
                  try
                  {
                      string jsonPlayer = File.ReadAllText(userName + ".txt");
                      Player player = JsonConvert.DeserializeObject<Player>(jsonPlayer);
                      player.ListDatesInRow = JsonConvert.DeserializeObject<List<DateTime>>(player.ListDatesInRowString);

                      return player;
                  }
                  catch (Exception ex)
                  {
                      throw new Exception($"Could not load player {userName} + {ex}");
                  }
              });
        }

        public static async Task<bool> RemoveUser(string userName)
        {
            return await Task.Run(() =>
            {
                try
                {
                    File.Delete(userName + ".txt");
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Could not remove player {userName} {ex}");
                }
            });
        }
    }
}