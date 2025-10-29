using MeetupWebsite.Data;
using MeetupWebsite.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MeetupWebsite.Pages
{
    public partial class EventPage(EventsRepository repository)
    {
        [Parameter]
        public int Id { get; set; }

        private EventEntry? currentEvent;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var pastEvents = await repository.GetEventsAsync();
                currentEvent = pastEvents.ElementAtOrDefault(Id - 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading past event details: {ex.Message}");
            }
        }
    }
}