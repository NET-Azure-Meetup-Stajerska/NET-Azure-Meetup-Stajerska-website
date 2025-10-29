using MeetupWebsite.Data;
using System.Net.Http.Json;

namespace MeetupWebsite.Services;

public class EventsRepository(HttpClient httpClient)
{
    private readonly Lazy<Task<List<EventEntry>>> cachedEvents = new(async () =>
    {
        return await httpClient.GetFromJsonAsync<List<EventEntry>>("data.json") ?? [];
    });

    public async Task<List<EventEntry>> GetEventsAsync()
    {
        return await cachedEvents.Value;
    }
}