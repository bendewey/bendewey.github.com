# GearHost exit and domain cutover

Ben approved moving the current site to Azure, retiring the GearHost WordPress
site, and ending GearHost charges. The new portfolio does not depend on a
WordPress content migration or a rollback copy.

## Current state

- `bendewey.com` is registered through Tucows with GearHost as reseller;
  registration expires on 2027-01-14. Its four registrar nameservers now point
  to the Azure DNS zone in `Default-Web-EastUS`. GearHost auto-renewal is off
  while the registration transfer is arranged.
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
- GearHost has three CloudSites (`bendewey`, `nuology`, `minimunchers`), three
  databases, and domain registrations for both `bendewey.com` and
  `nuology.com`. All three CloudSites are stopped. The
  `bendewey.com` mailboxes hold about 707.5 MB; Ben confirmed their historical
  messages already reached Hotmail and need no preservation.
- `nuology.com` uses Cloudflare DNS and ImprovMX MX records. Its ImprovMX
  domain, including the `ben` and catch-all aliases forwarding to
  `nuology.ben@gmail.com`, moved to the new `nuology.ben@gmail.com` account on
  2026-09-25. ImprovMX reports it active and accepted a test message. GearHost
  auto-renewal is off while its registration transfer is arranged.

## Remaining GearHost exit work

1. Retire the old GearHost mail service after Ben confirms permanent deletion
   of its stored mail. Confirm receipt of the Nuology alias test in Gmail.
2. Move domain registration to a registrar outside GearHost so renewals no
   longer bill through GearHost. This requires unlocking the domain and a
   transfer authorization code from its current reseller.
3. Move `nuology.com` registration outside GearHost as well while keeping its
   Cloudflare DNS and ImprovMX forwarding.
4. Remove the retired GearHost CloudSites and databases. GearHost's published
   account policy says account cancellation requires an email to
   `help@gearhost.com` after all services are removed and outstanding billing
   is resolved.

Do not cancel GearHost before domain registration and inbound mail are moved;
those services still depend on the account even though the website is live on
Azure.
