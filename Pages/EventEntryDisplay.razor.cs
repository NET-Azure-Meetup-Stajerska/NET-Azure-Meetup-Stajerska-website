using MeetupWebsite.Data;
using MeetupWebsite.Services;
using MeetupWebsite.Sessionize;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MeetupWebsite.Pages
{
    public partial class EventEntryDisplay(SessionizeClient sessionizeClient
        , ILogger<EventEntryDisplay> logger
        , NavigationManager navigationManager
        , IJSRuntime jsRuntime)
    {
        private SessionizeResponse? sessionizeData;
        private SessionizeDaySchedule[]? scheduleData;
        private bool _fancyboxInitialized = false;

        [Parameter]
        public EventEntry EventEntry { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var eventId = EventEntry.EventId;

                sessionizeData = await sessionizeClient.GetDataAsync(eventId);
                scheduleData = await sessionizeClient.GetScheduleAsync(eventId);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error fetching Sessionize data: {ex.Message}");
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (EventEntry.Photos?.Length > 0 && !_fancyboxInitialized)
            {
                _fancyboxInitialized = true;
                await jsRuntime.InvokeVoidAsync("initializeFancybox");
            }
        }

        private string PhotoUrl(string path) =>
            navigationManager.BaseUri + path.TrimStart('/');

        private MarkupString GetMarkup(string? text)
        {
            // put <br> tags in for new lines, since Sessionize uses plain text with new lines

            text = text?.Replace("\n", "<br />");
            return new MarkupString(text ?? string.Empty);
        }

    }
}