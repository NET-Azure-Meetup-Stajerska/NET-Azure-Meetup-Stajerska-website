# NET-Azure-Meetup-Stajerska-website

Source code for the [.NET & Azure Meetup Štajerska](https://dotnet-azure-meetup-stajerska.github.io/) community website — a group of developers and tech enthusiasts from the Štajerska region passionate about .NET, Azure, and related technologies.

The site displays upcoming and past events, per-event details with speaker sessions (via Sessionize), a photo gallery, and a link to join the community Discord.

## Tech stack

- [Blazor WebAssembly](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) (.NET 10) — runs entirely in the browser, no server required
- [Bootstrap 5](https://getbootstrap.com/) — UI components and layout
- [Sessionize API](https://sessionize.com/) — speaker and session data for each event
- Hosted as a static site on [GitHub Pages](https://pages.github.com/)

## Project structure

```
Pages/          Blazor pages (Home, Events list, Event detail, Gallery)
Data/           C# models for events (EventEntry, PastEvent, ...)
Services/       EventsRepository — loads event data from wwwroot/data.json
Sessionize/     SessionizeClient — fetches speaker/session data from the Sessionize API
Layout/         App shell (MainLayout, NavMenu)
wwwroot/        Static assets
  data.json     Upcoming events data (edit this to add/update events)
  Data/
    PastEvents.json  Past events list
  images/       Event photo galleries (organised by event date)
```

## Development

Prerequisites: [.NET 10 SDK](https://dotnet.microsoft.com/download)

```bash
dotnet run
```

The site is then available at `https://localhost:5001` (or the port shown in the terminal).

## Adding or updating events

1. Edit `wwwroot/data.json` to add or update upcoming events.
2. For past events, update `wwwroot/Data/PastEvents.json`.
3. Drop event photos into `wwwroot/images/<YYYYMMDD>/` and reference them in `data.json`.

## Publishing

Run the publish script from the project root:

```powershell
.\publish.ps1
```

This builds a Release version and copies the output to `../NET-Azure-Meetup-Stajerska.github.io`.  
Afterwards, go to that folder and push to GitHub to deploy:

```bash
git add .
git commit -m "Update site"
git push
```

## Contributing

Contributions are welcome! To get started:

1. Fork this repository and clone it locally.
2. Create a feature branch: `git checkout -b feature/my-change`
3. Make your changes and verify locally with `dotnet run`.
4. Open a pull request describing what you changed and why.

Please keep PRs focused — one change per PR makes review easier.
