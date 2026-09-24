# BenDewey.com

The future source repository for Ben Dewey's employer-facing portfolio at
`bendewey.com`.

This repository is intentionally being modernized from its small legacy GitHub
Pages starting point into a database-free ASP.NET Core Razor Pages application
hosted on Azure App Service. It is not the historical source of the live
GearHost WordPress site.

## What this site will do

- Tell a current, employer-oriented story: product leadership, technology
  transformation and delivery across complex digital platforms.
- Present a public Projects experience with generic project names and
  public-safe descriptions.
- Offer a single shared-password full-inventory view with only approved,
  non-confidential added detail.
- Link to Nuology as Ben's founder/product work. Nuology.com remains the
  prospective-client destination; only ThriftTrack is confirmed launched.
- Preserve useful legacy writing, talks and resources as a clearly dated
  archive after the WordPress content is recovered.

## Planned technical direction

ASP.NET Core Razor Pages on Azure App Service:

- no WordPress, CMS, database, Function, or separate API;
- public and approved project content stored as versioned Markdown/JSON files;
- the Razor Pages app owns the shared-password session;
- the password and session-signing secret live only in Azure App Service app
  settings, never in source control;
- a GitHub Actions workflow will build, test and deploy `main`.

The legacy [CNAME](CNAME) remains for now. It is not the production deployment
plan; domain cutover happens only after the Azure site, HTTPS and redirects
have been tested.

## Repository guide

- [Site brief](docs/site-brief.md) — audience, constraints and product scope.
- [Content plan](docs/content-plan.md) — sitemap, priority case studies and
  migration rules.
- [Technical plan](docs/technical-plan.md) — application, access-control and
  deployment approach.
- [Migration plan](docs/migration-plan.md) — how GearHost/WordPress becomes a
  verified archive and redirect ledger.
- [Project inventory integration](docs/project-inventory-integration.md) —
  source data and public/full presentation rules.
- [Portfolio design concept](design/portfolio-concept.html) — open locally in
  a browser; this is a visual direction, not production code.
- [Project inventory skill](.agents/skills/project-inventory/SKILL.md) —
  repository-local instructions for project-content work.

## Before development starts

1. Recover and independently back up the GearHost files and MySQL export.
2. Produce the migration ledger: legacy URL, title, media, disposition and
   redirect target.
3. Confirm public contact channels and which project details are approved for
   the shared-password view.
4. Create the Razor Pages solution and representative content in this repo.
5. Provision Azure App Service, configure deployment settings and test a
   staging deployment before DNS cutover.

Do not commit credentials, exports containing production data, or details that
are not authorized for sharing.

## Refreshing the project inventory

The deployed project pages read the generated
`src/BenDewey.Web/Content/projects.json` file. Refresh it after updating the
canonical job-search inventory:

```bash
./scripts/sync-project-inventory.sh
```

The script reads `/Users/bendewey/code/job-search/project-history` by default.
It accepts an alternate project-history directory as its first argument. The
generated catalog includes only records with a public-safe presentation entry
in `Content/project-presentation-overrides.json`. New canonical records stay
off the site until reviewed and added there. Three entries are marked as public
featured work; the other curated entries appear only in the protected inventory
when its password is configured.
