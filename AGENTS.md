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

## Current status

All three pages are built and verified (2026-10-16):

- Home: hero with welcome text, destination search (opens `/explore?q=...` with client-side navigation), category links, featured places.
- Explore: search by name or location, category buttons (`aria-pressed`), live result count, empty state with "Clear search and filters".
- Place Details: photo and credit, description, rating, sample and visitor reviews, a validated review form, and a not-found state for unknown slugs.
- Browser checks with Playwright all passed: filtering, validation (blank and whitespace-only fields, integer 1–5),
  average updates immediately, reviews kept across internal navigation, reset on refresh, two visitors isolated,
  focus moves to the `h1` on navigation, focus ring visible, all images have alt text, no horizontal scroll at 390px wide, no console errors.

Design: the owner decided to keep this site's design and recreate it in Figma (not the other way round).
If a Figma file arrives later, change the `@theme` tokens and shared classes in `Styles/app.css` first.

Accessibility note: there's no skip link on purpose. `FocusOnNavigate` (in `Routes.razor`) focuses each page's `h1`, and
`href="#..."` links resolve against `<base href="/">`, so they would navigate to Home.
