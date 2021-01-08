namespace MedGame.GameLogic
{
    public class MultiplicatorCounter
    {
        public static double CalculateMultiplicator(int totalDaysMieesd, double currentMultiplicatorPoints)
        {
            //Point punishment by reduced multiplicator
            double multiplicatorTemp = 0;
            if (totalDaysMieesd == 1) { multiplicatorTemp = (double)(currentMultiplicatorPoints * 0.80); }
            else if (totalDaysMieesd == 2) { multiplicatorTemp = (double)(currentMultiplicatorPoints * 0.50); }
            else { multiplicatorTemp = 1; }
            if (multiplicatorTemp == 0) { multiplicatorTemp = 1; }
            return multiplicatorTemp;
        }
    }
}