using System;
using ReactiveUI;

namespace AchtGewinnt.Models
{
    public class Meeting : ReactiveObject
    {
        private DateTimeOffset date;
        private string title;
        private string description;

        public int Id { get; set; }
        public DateTimeOffset Date { get => date; set => this.RaiseAndSetIfChanged(ref date, value); }
        public string Title { get => title; set => this.RaiseAndSetIfChanged(ref title, value); }
        public string Description { get => description; set => this.RaiseAndSetIfChanged(ref description, value); }

        // ToDo
        // Rating Property
    }
}
