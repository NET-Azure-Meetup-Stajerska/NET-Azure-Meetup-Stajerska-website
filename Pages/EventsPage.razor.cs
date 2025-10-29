using MeetupWebsite.Data;
using MeetupWebsite.Services;
using System.Net.Http.Json;

namespace MeetupWebsite.Pages
{
    public partial class EventsPage(EventsRepository repository)
    {
        private List<EventEntry>? pastEvents;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                pastEvents = await repository.GetEventsAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading past events: {ex.Message}");
            }
        }
    }
}