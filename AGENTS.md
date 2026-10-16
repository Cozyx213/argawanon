# AGENTS.md: Argawanon

Argawanon is a student school project: a tourism website about **Argao, Cebu** (heritage, local food, nature),
built on this existing **.NET 8 Blazor** app (`MyBlazorApp`). Keep everything simple enough for a student to explain.

## Hard requirements

- .NET 8 Blazor (Interactive Server), **Tailwind CSS only**. Bootstrap has been removed; don't add it back.
- **No** database, accounts, authentication, or browser storage (no localStorage/sessionStorage/cookies for data).
- **Exactly three pages**: Home `/`, Explore `/explore`, Place Details `/places/{slug}`.
  About information lives in the footer (`Components/Layout/MainLayout.razor`), not on a fourth page.
- 9 listings, 3 per category (Attractions, Food, Stays). They're already in `Data/Places.cs`.
- Food and Stays listings are **fictional demonstrations**, and sample reviews are **fictional**. Label both clearly in the UI
  (`Place.IsDemo`, `Review.IsSample`). Never invent real business claims, prices or opening hours.
- Reviews: `Data/ReviewStore.cs` is registered **Scoped** (one per visitor circuit). Never make it a singleton or static.
  Reviews survive internal navigation but reset on a full refresh. That works because the whole site uses the global
  `InteractiveServer` render mode (`Components/App.razor`).
  - Navigate with links or `NavigationManager.NavigateTo`. **Do not** use plain `<form method="get">` or
    `forceLoad: true`, because a full page load starts a new circuit and wipes the visitor's reviews.
- Accessibility: real `<label for>` on every input, keyboard-usable controls (buttons, not clickable divs),
  visible focus (global `:focus-visible` style in `Styles/app.css`), and alt text from `Place.ImageAlt`.
- Responsive for desktop and mobile.

## Styling

- Source: `Styles/app.css`. Output: `wwwroot/app.css` (generated, **but committed** so `dotnet run` works without npm).
- After changing any `.razor` classes or `Styles/app.css`, run `npm run css:build` and commit the regenerated `wwwroot/app.css`.
- Design tokens (`@theme`): `ocean-*` (teal), `sand-*` (backgrounds), `coral-*` (accents), `font-display` (Fraunces),
  `font-sans` (Nunito Sans). Shared classes: `container-page`, `heading`, `btn-primary`, `btn-secondary`, `card`,
  `field-label`, `field`, `badge`, `demo-tag`.
- A Figma design will arrive later, so put shared look-and-feel in tokens, shared classes, and `Components/Shared/*`
  components rather than repeating long class lists across pages.
- Tailwind v4 can't `@apply` a custom class (e.g. `@apply btn`). Repeat the utilities instead.

## Content and images

- Photos are in `wwwroot/images/` from Wikimedia Commons; licenses and authors are in `wwwroot/images/CREDITS.md`.
  Each `Place.PhotoCredit` must stay visible on the details page (CC BY / BY-SA require attribution).
- Stay photos show Argao scenery, not the fictional properties. The credit text says so; keep that.
- Don't add new images without checking that they really show Argao (one Commons file named "Argao" was actually a European town).

## Commands

```bash
npm install            # first time only (Tailwind CLI)
npm run css:build      # or: npm run css:watch
dotnet build
dotnet run             # http://localhost:5095
```

## Git

- Small, incremental commits using **Conventional Commits** (`feat:`, `fix:`, `build:`, `chore:`, `docs:`, `style:`, `refactor:`).
- **No** `Co-Authored-By` or AI attribution lines. Keep commits clean.
- `bin/`, `obj/` and `node_modules/` are git-ignored.

## Current status (handoff)

Done (one commit each):
1. `build:` Tailwind replaces Bootstrap (tokens and shared classes)
2. `feat:` Argao photos plus credits
3. `feat:` `Data/Place.cs` (records), `Data/Places.cs` (9 listings, `Find(slug)`), `Data/ReviewStore.cs` (scoped, registered in `Program.cs`)
4. `feat:` new layout (header nav, footer About, skip link), global InteractiveServer render mode; Counter/Weather/NavMenu removed

Remaining:
1. **`Components/Shared/PlaceCard.razor`**: the whole card is a link to `places/{slug}`, with photo (`ImageAlt`), name, location,
   category badge, `demo-tag` when `IsDemo`, and average rating from `ReviewStore.AverageRating`
   (e.g. "★ 4.5" with `aria-label="Average rating 4.5 out of 5"`). Add `@using MyBlazorApp.Components.Shared` to `_Imports.razor`.
2. **Home (`Components/Pages/Home.razor`)**: a large hero using `images/shore.jpg` with its credit, the Argawanon welcome to Argao,
   and a destination search (label plus input) that calls `NavigationManager.NavigateTo($"explore?q={Uri.EscapeDataString(q)}")`
   from `@onsubmit`. Show featured places (first place of each category) as PlaceCards, plus three category links to
   `explore?category=Attractions|Food|Stays`.
3. **Explore (`/explore`)**: `[SupplyParameterFromQuery] q` and `category` initialize the state in `OnParametersSet`.
   Add a search input (name or location, case-insensitive, trimmed, filters while typing via `@bind:event="oninput"`) and category
   buttons (All / Attractions / Food / Stays) with `aria-pressed`. Show a results count in an `aria-live` region and a grid of PlaceCards.
   The empty state explains that nothing matched and offers a "Clear search and filters" button plus category suggestions.
4. **Place Details (`/places/{Slug}`)**: `Places.Find(Slug)`. For an unknown slug, show a friendly "Place not found"
   message with a link back to Explore. Otherwise show a large photo with credit, name, category, location, demo label, description,
   average rating with review count, and the review list (label sample reviews "Sample review (fictional)" and visitor ones "Your review").
   The review form is an `EditForm` with `DataAnnotationsValidator`, using a model with `[Required] string Name`
   (`[StringLength(40)]`), `[Required, Range(1,5)] int? Rating` (an `InputSelect` with options 1–5), and `[Required] string Comment`
   (`[StringLength(500)]`). `[Required]` already rejects whitespace-only text. On valid submit, call `ReviewStore.Add(place, new Review(name.Trim(), rating, comment.Trim()))`,
   reset the form, and announce success in an `aria-live` region. The new review and the updated average appear immediately.
5. Run `npm run css:build` and `dotnet build`, then verify in a browser: filtering, review validation, rating updates, navigation
   (review kept after Home→Explore→back), full refresh resets reviews, and two separate browser windows don't share reviews.
6. Update this status section when you're done.
