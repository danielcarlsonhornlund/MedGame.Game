﻿using MedGame.Models;
using System;
using System.Windows.Threading;

namespace MedGame.GameLogic
{
    public class Game
    {
        public static Player Player = new Player();

        private static DispatcherTimer MeditationTimer { get; set; }

        public static void StartMeditation()
        {
            MeditationTimer = new DispatcherTimer();
            MeditationTimer.Interval = TimeSpan.FromSeconds(1);
            MeditationTimer.Tick += (object sender, EventArgs e) =>{ Game.Player.TotalMinutesMeditatedToday++; };
            MeditationTimer.Start();
        }

        public static void StopMeditation()
        {
            MeditationTimer.Stop();

            if (CheckSameDate())
            {
                Game.Player.LastDateMeditated = DateTime.Now;
                Game.Player.TotalMinutesMeditated += Game.Player.TotalMinutesMeditatedToday;
            }
            else
            {
                Game.Player.LastDateMeditated = DateTime.Now;
                Game.Player.TotalMinutesMeditated += Game.Player.TotalMinutesMeditatedToday;
                Game.Player.Points = Game.Player.Points + (Game.Player.TotalMinutesMeditatedToday * Game.Player.Multiplicator);
                Game.Player.TotalMinutesMeditatedToday = 0;
            }
            
            Game.Player.TotalDaysMissed = 0;
            Game.Player.TotalHoursMissed = 0;
        }



        private static bool CheckSameDate()
        {
            if (Game.Player.LastDateMeditated.Date == DateTime.Now.Date)
            {
                return true;
            }
            return false;
        }

    }
}
