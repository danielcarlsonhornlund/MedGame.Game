namespace MedGame.GameLogic
{
    public class MultiplicatorCounter
    {
        public static double CalculateMultiplicator(int totalDaysMissed, double currentMultiplicatorPoints)
        {
            //Point punishment by reduced multiplicator
            double multiplicatorTemp = 0;
            if (totalDaysMissed == 1) { multiplicatorTemp = (double)(currentMultiplicatorPoints * 0.80); }
            else if (totalDaysMissed == 2) { multiplicatorTemp = (double)(currentMultiplicatorPoints * 0.50); }
            else { multiplicatorTemp = 1; }

            return currentMultiplicatorPoints;
        }
    }
}