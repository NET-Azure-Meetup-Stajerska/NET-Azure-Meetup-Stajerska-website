using MeetupWebsite.Data;
using MeetupWebsite.Services;
using MeetupWebsite.Sessionize;
using Microsoft.AspNetCore.Components;

namespace MeetupWebsite.Pages
{
    public partial class Home(EventsRepository repository, ILogger<Home> logger, IConfiguration configuration)
    {
        private EventEntry? eventEntry;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                eventEntry = (await repository.GetEventsAsync()).First();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error fetching data: {ex.Message}");
            }
        }

    }
}