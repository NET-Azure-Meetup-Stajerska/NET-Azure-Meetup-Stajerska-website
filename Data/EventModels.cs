namespace NET_Azure_Meetup_Stajerska_website.Data
{
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
