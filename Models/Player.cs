using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedGame.Models
{
    public class player
    {
        public string FacebookId { get; set; } = string.Empty;
        public string FacebookFullName { get; set; } = string.Empty;
        public string FacebookPicture { get; set; } = string.Empty;
        public string FacebookDateOfBirth { get; set; } = string.Empty;
        public string FacebookGender { get; set; } = string.Empty;
        public string FacebookLastName { get; set; } = string.Empty;
        public string FacebookFirstName { get; set; } = string.Empty;
        public string FacebookEmail { get; set; } = string.Empty;

        [NotMapped]
        public List<DateTime> ListDatesInRow { get; set; } = new List<DateTime>();
        public string Address { get; set; } = string.Empty;
        public string ListDatesInRowString { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Levels Level { get; set; } = Levels.Baby;
        public int Points { get; set; } = 0;
        public int TotalMinutesMeditated { get; set; } = 0;
        public int TotalMinutesMeditatedToday { get; set; } = 0;
        public int Health { get; set; } = 72;
        public DateTime LastDateMeditated { get; set; } = DateTime.Now;
        public int TotalDaysMeditatedInRow { get; set; } = 1;
        public int TotalDaysMissed { get; set; } = 0;
        public int TotalHoursMissed { get; set; } = 0;
        public double Multiplicator { get; set; } = 1;
        public string FacebookAccessToken { get; set; } = string.Empty;
        public string PlayerMessage { get; set; } = string.Empty;
        public string HttpResult { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}