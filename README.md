# Argawanon

A tourism website about **Argao, Cebu**, covering its heritage, local food and nature. It is a school project
built with **.NET 8 Blazor** and **Tailwind CSS**.

## Pages

| Page | URL | What it does |
|---|---|---|
| Home | `/` | Welcome to Argao, destination search, category links and featured places |
| Explore | `/explore` | All 9 places, with search by name or location and a category filter |
| Place Details | `/places/{slug}` | Photo, description, rating, reviews and a review form |

## How it works

- **Data:** the places and sample reviews are a fixed list in `Data/Places.cs`. There's no database.
- **Reviews:** `Data/ReviewStore.cs` keeps reviews in memory. It is registered as a *scoped* service, so each visitor
  gets their own copy. Reviews stay while you move between pages and disappear when you refresh.
- **Interactivity:** the whole site uses Blazor's Interactive Server render mode (`Components/App.razor`).
- **Styling:** Tailwind CSS. Colors, fonts and shared classes such as `btn-primary` and `card` are in `Styles/app.css`.

## Run it locally

Requirements: [.NET 8 SDK](https://dotnet.microsoft.com/download) and [Node.js](https://nodejs.org/) (Node is only needed to rebuild the CSS).

```bash
npm install          # first time only, installs the Tailwind CLI
npm run css:build    # rebuild wwwroot/app.css after changing styles (or: npm run css:watch)
dotnet run           # open http://localhost:5095
```

The compiled CSS (`wwwroot/app.css`) is committed, so `dotnet run` works on its own if you haven't changed any styles.

## Project structure

```
Components/
  App.razor            HTML shell and render mode
  Layout/MainLayout    Header, footer (About section)
  Pages/               Home, Explore, PlaceDetails, Error
  Shared/              PlaceCard, Rating
Data/                  Place records, place list, ReviewStore
Styles/app.css         Tailwind source (theme tokens and shared classes)
wwwroot/               Compiled CSS and images
```

## Disclaimer

Food and stay listings are **fictional demonstrations**, and all sample reviews are **fictional**. The site makes no claims
about real businesses, prices or opening hours. Photos come from Wikimedia Commons contributors; see
`wwwroot/images/CREDITS.md`.
