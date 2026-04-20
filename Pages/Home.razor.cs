using MeetupWebsite.Data;
using MeetupWebsite.Services;
using Microsoft.AspNetCore.Components;

namespace MeetupWebsite.Pages
{
    public partial class Home(EventsRepository repository, ILogger<Home> logger)
    {
        private List<(int Index, EventEntry Event)>? upcomingEvents;
        private List<(int Index, EventEntry Event)>? pastEvents;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var now = DateTimeOffset.UtcNow;
                var all = (await repository.GetEventsAsync())
                    .Index()
                    .Select(x => (Index: x.Index + 1, Event: x.Item))
                    .ToList();

                upcomingEvents = all.Where(x => x.Event.EventStartsAt > now).ToList();
                pastEvents = all.Where(x => x.Event.EventStartsAt <= now).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError("Error fetching events: {Message}", ex.Message);
                upcomingEvents = [];
                pastEvents = [];
            }
        }
    }
}