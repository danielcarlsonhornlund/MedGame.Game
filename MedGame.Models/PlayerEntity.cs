using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedGame.Models
{
    public class PlayerEntity
    {
        public string FacebookId { get; set; } = "0";
        public string FacebookFullName { get; set; } = "0";
        public string FacebookPicture { get; set; } = "0";
        public string FacebookDateOfBirth { get; set; } = "0";
        public string FacebookGender { get; set; } = "0";
        public string FacebookLastName { get; set; } = "0";
        public string FacebookFirstName { get; set; } = "0";
        public string FacebookEmail { get; set; } = "0";

        [NotMapped]
        public List<DateTime> ListDatesInRow { get; set; } = new List<DateTime>();

        public string ListDatesInRowString { get; set; } = "0";
        public string Password { get; set; } = "0";
        public string Level { get; set; } = "Child";
        public int Points { get; set; } = 0;
        public int TotalMinutesMeditated { get; set; } = 0;
        public int TotalMinutesMeditatedToday { get; set; } = 0;
        public int Health { get; set; } = 72;
        public DateTime LastDateMeditated { get; set; } = DateTime.Now;
        public int TotalDaysMeditatedInRow { get; set; } = 1;
        public int TotalDaysMissed { get; set; } = 0;
        public int TotalHoursMissed { get; set; } = 0;
        public int Multiplicator { get; set; } = 1;
        public string FacebookAccessToken { get; set; } = "0";
        public string PlayerMessage { get; set; } = "0";
        public string HttpResult { get; set; } = "0";
    }
}
