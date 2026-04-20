using MeetupWebsite.Data;
using MeetupWebsite.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MeetupWebsite.Pages
{
    public partial class EventPage(EventsRepository repository)
    {
        [Parameter]
        public string Slug { get; set; } = "";

        private EventEntry? currentEvent;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var events = await repository.GetEventsAsync();
                currentEvent = events.FirstOrDefault(e => e.Slug == Slug);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading past event details: {ex.Message}");
            }
        }
    }
}