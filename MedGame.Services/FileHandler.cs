using MedGame.GameLogic;
using MedGame.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MedGame.Services
{
    public class FileHandler
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
            return await Task.Run(async () =>
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
                      await SavePlayerToFile(GamePlay.Player, userName); // only under development
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

        public static string GetFullFileNamePath(string fileName)
        {
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return appRoot + fileName;
        }
    }
}