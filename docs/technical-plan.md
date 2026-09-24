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
| Transactional email provider | Delivers contact-form messages through credentials held in App Service settings. |
| GitHub Actions | Build, test and deploy `main` to App Service. |

No database, CMS, Function, separate API or client-side framework is required.
The Razor Pages application handles the contact-form post and calls the email
provider directly.

## Contact form

`/contact` accepts name, email, optional company/role and message. Server-side
validation, a hidden honeypot field and rate limiting protect the endpoint.
The recipient address, sender address and transactional-email provider
credentials live in App Service settings. The public site never exposes them.

### Current outbound mail configuration (2026-09-24)

The contact form sends through Azure Communication Services SMTP at
`smtp.azurecomm.net:587` with TLS. The Email Communication resource is
`bendewey-site-email`; its Azure-managed sender domain is linked to
`bendewey-site-comm`. A dedicated Entra application, `bendewey-site-smtp`,
authenticates SMTP under the scoped custom role `BenDewey Site SMTP Sender`.
The recipient is `ben@bendewey.com`, and the sender uses the Azure-managed
domain until Ben chooses to verify a custom sending domain.

The SMTP client secret is stored only as `ContactEmail__Password` in the
`bendewey-blog` App Service settings. It expires on 2027-09-24 and must be
rotated before then. The other `ContactEmail__*` settings are also held in App
Service. A live contact-form test returned a send confirmation on 2026-09-24;
inbox receipt still needs confirmation from Ben. Inbound mail forwarding is a
separate ImprovMX cutover recorded in the migration plan.

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
