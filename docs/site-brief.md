# Site brief

## Purpose

Build a current, employer-facing portfolio for Ben Dewey. The site should make
his product leadership, technology transformation and delivery experience easy
to understand, then support it with carefully selected work.

Nuology.com is the prospective-client destination. BenDewey.com will include a
concise Nuology founder/product bridge; it is not a replacement for Nuology.com.

## Audience

Primary: prospective employers, recruiters and hiring managers.

Secondary: professional peers assessing Ben's work and point of view.

## Product constraints

- Modern ASP.NET Core Razor Pages application on Azure App Service.
- No database, WordPress, CMS, serverless Function or separate API.
- Content is versioned Markdown/JSON in the application repository.
- Anonymous visitors see generic project labels and public-safe descriptions.
- One shared password grants a short-lived full-inventory session.
- The full view contains only details approved for sharing; a password is not a
  substitute for client permission or a place for secrets.
- Password and session-signing secret are rotatable App Service settings, never
  source-controlled.

## Editorial rules

- State roles, dates, outcomes and launch status only when source-backed.
- Do not imply client endorsement, publish proprietary workflows or expose
  credentials, PII, confidential metrics or NDA-covered material.
- Only ThriftTrack is confirmed launched among the current Nuology products.
- Preserve the old WordPress content as dated archive material rather than
  presenting it as current practice.
