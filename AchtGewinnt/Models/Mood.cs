using System;
using ReactiveUI;

namespace AchtGewinnt.Models
{
    public class Mood : ModelBase
    {
        private DateTimeOffset date;
        private string description;
        private MoodRating rating;

        public DateTimeOffset Date { get => date; set => this.RaiseAndSetIfChanged(ref date, value); }
        public string Description { get => description; set => this.RaiseAndSetIfChanged(ref description, value); }
        public MoodRating Rating
        {
            get => rating;
            set => this.RaiseAndSetIfChanged(ref rating, value);
        }

    }
}
