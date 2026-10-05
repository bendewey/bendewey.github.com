# GearHost exit and domain cutover

Ben approved moving the current site to Azure, retiring the GearHost WordPress
site, and ending GearHost charges. The new portfolio does not depend on a
WordPress content migration or a rollback copy.

## Current state

- `bendewey.com` transferred from Tucows/GearHost to GoDaddy on 2026-10-05.
  GoDaddy lists it as active, with registration through 2028-01-14. Its four
  nameservers still point to the Azure DNS zone in `Default-Web-EastUS`.
- `bendewey.com` and `www.bendewey.com` are bound to `bendewey-blog` with
  Azure-managed TLS certificates. The apex serves the site over HTTPS and
  `www` redirects to the apex.
- Azure DNS now routes inbound mail to ImprovMX (`mx1.improvmx.com` and
  `mx2.improvmx.com`) and publishes its SPF record. The ImprovMX account
  `bdewey01@hotmail.com` holds `bendewey.com`; both `ben@bendewey.com` and the
  catch-all forward to that Hotmail inbox. ImprovMX reports the domain active
  and a test message arrived in Hotmail. The obsolete `mail.bendewey.com`
  GearHost alias has been removed.
- Outbound site contact mail already uses Azure Communication Services SMTP.
  `ben@bendewey.com` is the recipient. Outbound SMTP and inbound forwarding
  are separate services. A live contact-form submission on 2026-09-25 arrived
  in Hotmail through Azure Communication Services and ImprovMX.
- GitHub Actions deploys `master` to Azure using OpenID Connect. The first
  remote workflow run completed successfully on 2026-09-25.
- GearHost originally had three stopped CloudSites (`bendewey`, `nuology`,
  `minimunchers`) and three databases. On 2026-10-05, the GearHost account
  showed no remaining CloudSites, databases, or certificates. Billing showed
  $0 currently due, $0 current-month usage, and a $0 monthly estimate. The
  `bendewey.com` mailboxes had held about 707.5 MB; Ben confirmed their
  historical messages already reached Hotmail and needed no preservation.
- `nuology.com` transferred from Tucows/GearHost to GoDaddy on 2026-10-05.
  GoDaddy lists it as active, with registration through 2028-03-17 and its
  Cloudflare nameservers intact. It uses Cloudflare DNS and ImprovMX MX records.
  Its ImprovMX domain, including the `ben` and catch-all aliases forwarding to
  `nuology.ben@gmail.com`, moved to the new `nuology.ben@gmail.com` account on
  2026-09-25. ImprovMX reports it active, and Ben confirmed a test message
  arrived.
- Ben selected GoDaddy as the destination registrar for both domains, since his
  other domains are there. Registrar Lock was disabled for both on 2026-09-25.
  GearHost supplied both EPP authorization codes by email. Ben completed the
  GoDaddy checkout on 2026-09-29 (confirmation `4192293468`): one-year
  transfers for both domains, $26.38 total including taxes and fees, with no
  protection add-ons. GoDaddy emailed confirmation for both domains on
  2026-10-05. Its domain portfolio lists both as **Active**. A check of
  GoDaddy's settings on 2026-10-05 showed Azure nameservers for `bendewey.com`
  and Cloudflare nameservers for `nuology.com`. Browser checks loaded the
  portfolio at `https://bendewey.com/` and confirmed
  `https://www.bendewey.com/` redirects there. The nuology.com ImprovMX
  dashboard still reports its forwarding domain **Active**. A new inbound
  mail test after transfer has not yet been recorded.
- Ben approved GearHost account closure on 2026-10-05. The account's
  self-service **Deactivate My Account** flow completed and displayed
  **Account Deactivated**. The GearHost Domains page had still listed
  `nuology.com` as active immediately before deactivation, despite GoDaddy
  listing it as active in Ben's new registrar portfolio; its GearHost
  auto-renewal was off. The Ben Dewey site still loaded over HTTPS after
  deactivation.

## Remaining check

Send fresh inbound test messages to `ben@bendewey.com` and
`ben@nuology.com` and confirm both reach their intended inboxes after the
registrar transfer and GearHost deactivation.
