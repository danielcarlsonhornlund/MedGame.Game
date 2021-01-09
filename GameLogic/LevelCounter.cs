using MedGame.Models;
using System;

namespace MedGame.GameLogic
{
    public class LevelCounter
    {
        public static Levels CheckLevel(double playerPoints)
        {
            if (playerPoints >= 0 && playerPoints <= 10) { return Levels.Baby; }
            else if (playerPoints >= 11 && playerPoints <= 20) { return Levels.Child; }
            else if (playerPoints >= 21 && playerPoints <= 30) { return Levels.Teenager; }
            else if (playerPoints >= 31 && playerPoints <= 40) { return Levels.Pupil; }
            else if (playerPoints >= 41 && playerPoints <= 50) { return Levels.YoungAdult; }
            else if (playerPoints >= 51 && playerPoints <= 60) { return Levels.Adult; }
            else if (playerPoints >= 61 && playerPoints <= 70) { return Levels.OldAdult; }
            else if (playerPoints >= 71 && playerPoints <= 80) { return Levels.Old; }
            else if (playerPoints >= 81 && playerPoints <= 90) { return Levels.Master; }
            else if (playerPoints >= 91 && playerPoints <= 100) { return Levels.Munk; }
            else return Levels.God;
        }
    }
}
