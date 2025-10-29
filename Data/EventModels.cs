using System.Text.Json.Serialization;

namespace MeetupWebsite.Data
{

    public class EventEntry
    {
        [JsonPropertyName("eventId")]
        public string EventId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("callForPapersUrl")]
        public string CallForPapersUrl { get; set; }
        [JsonPropertyName("ticketsUrl")]
        public string TicketsUrl { get; set; }
        [JsonPropertyName("photos")]
        public string[] Photos { get; set; }
        [JsonPropertyName("eventStartsAt")]
        public DateTimeOffset EventStartsAt { get; set; }
        [JsonPropertyName("eventEndsAt")]
        public DateTimeOffset EventEndsAt { get; set; }
        [JsonPropertyName("location")]
        public EventEntryLocation Location { get; set; }
    }

    public class EventEntryLocation
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("mapsUrl")]
        public string MapsUrl { get; set; }
        [JsonPropertyName("embeddedMapUrl")]
        public string EmbeddedMapUrl { get; set; }
        [JsonPropertyName("parkings")]
        public EventEntryLocationParking[] Parkings { get; set; }

    }

    public class EventEntryLocationParking
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("mapsUrl")]
        public string MapsUrl { get; set; }
    }

    public class PastEvent
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string? Location { get; set; }
        public string? Title { get; set; }
        public Speaker[]? Speakers { get; set; }
        public AgendaItem[]? Agenda { get; set; }
        public ImageInfo[]? Images { get; set; }
    }

    public class Speaker
    {
        public string? Name { get; set; }
        public string? Talk { get; set; }
    }

    public class AgendaItem
    {
        public string? Time { get; set; }
        public string? Topic { get; set; }
    }

    public class ImageInfo
    {
        public string? Thumbnail { get; set; }
        public string? Full { get; set; }
    }
}
