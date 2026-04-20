using MeetupWebsite.Data;
using MeetupWebsite.Services;

namespace MeetupWebsite.Pages
{
    public partial class EventsPage(EventsRepository repository)
    {
        private List<EventEntry>? allEvents;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                allEvents = (await repository.GetEventsAsync()).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading events: {ex.Message}");
                allEvents = [];
            }
        }
    }
}