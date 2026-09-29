# GearHost exit and domain cutover

Ben approved moving the current site to Azure, retiring the GearHost WordPress
site, and ending GearHost charges. The new portfolio does not depend on a
WordPress content migration or a rollback copy.

## Current state

- `bendewey.com` is transferring from Tucows/GearHost to GoDaddy;
  its pre-transfer registration expires on 2027-01-14. Its four registrar
  nameservers point to the Azure DNS zone in `Default-Web-EastUS`. GearHost
  auto-renewal is off.
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
  `minimunchers`) and three databases. Deletion of the `bendewey` CloudSite
  was initiated on 2026-09-25; inventory of the remaining services needs a
  fresh check before account closure. The `bendewey.com` mailboxes held about
  707.5 MB; Ben confirmed their historical messages already reached Hotmail
  and need no preservation.
- `nuology.com` uses Cloudflare DNS and ImprovMX MX records. Its ImprovMX
  domain, including the `ben` and catch-all aliases forwarding to
  `nuology.ben@gmail.com`, moved to the new `nuology.ben@gmail.com` account on
  2026-09-25. ImprovMX reports it active, and Ben confirmed a test message
  arrived. GearHost auto-renewal is off while its registration transfer is
  arranged.
- Ben selected GoDaddy as the destination registrar for both domains, since his
  other domains are there. Registrar Lock was disabled for both on 2026-09-25.
  GearHost supplied both EPP authorization codes by email. Ben completed the
  GoDaddy checkout on 2026-09-29 (confirmation `4192293468`): one-year
  transfers for both domains, $26.38 total including taxes and fees, with no
  protection add-ons. GoDaddy's Transfers In page shows both **In progress**,
  initiated 2026-09-29 and expected by 2026-10-06. Public DNS checks after
  checkout still returned Azure nameservers for `bendewey.com`, Cloudflare
  nameservers for `nuology.com`, and ImprovMX MX records for both.

## Remaining GearHost exit work

1. Retire the old GearHost mail service after Ben confirms permanent deletion
   of its stored mail.
2. Watch the two GoDaddy incoming transfers, complete any email approvals if
   requested, and verify both registrations move while keeping the current
   Azure and Cloudflare nameservers.
3. Inventory and remove any remaining retired GearHost CloudSites and
   databases. GearHost's published account policy says to request cancellation
   by emailing `help@gearhost.com` after removing all services and resolving
   outstanding billing.

Do not cancel GearHost before domain registration and inbound mail are moved;
those services still depend on the account even though the website is live on
Azure.
