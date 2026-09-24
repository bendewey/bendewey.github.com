# BenDewey.com

Source for Ben Dewey's employer-facing portfolio. The current Azure site is
`https://bendewey-blog.azurewebsites.net`; `bendewey.com` is being moved here.

The site is a database-free ASP.NET Core Razor Pages application on Azure App
Service. This repository is not the historical source of the GearHost WordPress
site.

## Site content

- Tell a current, employer-oriented story: product leadership, technology
  transformation and delivery across complex digital platforms.
- Present a public Projects experience with generic project names and
  public-safe descriptions.
- Offer a single shared-password full-inventory view with only approved,
  non-confidential added detail.
- Link to Nuology as Ben's founder/product work. Nuology.com remains the
  prospective-client destination; only ThriftTrack is confirmed launched.
- Present selected legacy writing and speaking as a dated archive.

## Hosting and deployment

ASP.NET Core Razor Pages on Azure App Service:

- no WordPress, CMS, database, Function, or separate API;
- public and approved project content stored as versioned Markdown/JSON files;
- the Razor Pages app owns the shared-password session;
- the password and session-signing secret live only in Azure App Service app
  settings, never in source control;
- [GitHub Actions](.github/workflows/deploy.yml) builds and deploys `master`
  automatically using Azure OpenID Connect; Ben will push the prepared local
  commits when the cutover work is finished.

Azure DNS has a staged `bendewey.com` zone. GearHost remains the registrar
reseller and active DNS host until the domain's nameservers are changed. The
App Service plan is Basic B1 because custom domains require a paid tier.

## Repository guide

- [Site brief](docs/site-brief.md) — audience, constraints and product scope.
- [Content plan](docs/content-plan.md) — sitemap, priority case studies and
  migration rules.
- [Technical plan](docs/technical-plan.md) — application, access-control and
  deployment approach.
- [Migration plan](docs/migration-plan.md) — GearHost exit and inbound mail
  transition notes.
- [Project inventory integration](docs/project-inventory-integration.md) —
  source data and public/full presentation rules.
- [Portfolio design concept](design/portfolio-concept.html) — open locally in
  a browser; this is a visual direction, not production code.
- [Project inventory skill](.agents/skills/project-inventory/SKILL.md) —
  repository-local instructions for project-content work.

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
