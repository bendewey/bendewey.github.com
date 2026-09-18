# Technical plan

## Architecture

Use one lightweight ASP.NET Core Razor Pages application deployed to Azure App
Service. It is server-rendered and dynamic where useful, but database-free:

| Component | Responsibility |
| --- | --- |
| Razor Pages app | Renders public pages and the full-inventory route. |
| Markdown/JSON files | Versioned public content, approved project data and redirect map. |
| Protected content files outside `wwwroot` | Richer, approved inventory data and private-safe assets. |
| Azure App Service | Production runtime, custom domains, TLS and configuration. |
| App Service settings | Shared password and session-signing secret. |
| GitHub Actions | Build, test and deploy `main` to App Service. |

No database, CMS, Function, separate API or client-side framework is required.

## Shared-password flow

1. Anonymous routes render generic project names and descriptions only.
2. `/projects/full` accepts the shared password over HTTPS.
3. The app compares it to the App Service setting.
4. On success it issues a short-lived `HttpOnly`, `Secure`, `SameSite`
   session cookie.
5. The full route renders only approved richer content.

Password rotation belongs in App Service settings. It should invalidate existing
sessions and not require a code deployment.

This is intentionally a convenience gate, not strong authorization. It cannot
make confidential material safe to distribute.

## Deployment and domain cutover

1. Create the App Service and a GitHub deployment identity/secret.
2. Deploy a staging build and test mobile behavior, accessibility, SEO, full
   inventory sessions and redirects.
3. Validate `bendewey.com` and `www.bendewey.com` through the DNS records
   Azure requests.
4. Enable managed HTTPS/TLS and verify both hostnames.
5. Move production DNS only after migration-ledger and redirect tests pass.
6. Keep GearHost untouched until the replacement and independent backups are
   confirmed.

Azure DNS is optional; retain the current DNS provider unless moving it makes
apex-domain configuration or administration materially simpler.
