using Newtonsoft.Json;

namespace MedGame.DTO.User
{
    public class User
    {
        public string ObjectId { get; set; }

        public string BodyWeight { get; set; }

        public string BodyHeight { get; set; }

        public string TotalBurnedCalories { get; set; }

        public string TotalWorkoutHours { get; set; }

        public string Total { get; set; }
    }
}
