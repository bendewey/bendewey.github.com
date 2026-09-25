# GearHost exit and domain cutover

Ben approved moving the current site to Azure, retiring the GearHost WordPress
site, and ending GearHost charges. The new portfolio does not depend on a
WordPress content migration or a rollback copy.

## Current state

- `bendewey.com` is registered through Tucows with GearHost as reseller;
  registration expires on 2027-01-14. Its four registrar nameservers now point
  to the Azure DNS zone in `Default-Web-EastUS`.
- `bendewey.com` and `www.bendewey.com` are bound to `bendewey-blog` with
  Azure-managed TLS certificates. The apex serves the site over HTTPS and
  `www` redirects to the apex.
- Azure DNS temporarily preserves `mail2.gearhost.com` as the MX destination
  and `mail.bendewey.com` as a GearHost alias. Change both when ImprovMX
  forwarding is active.
- Outbound site contact mail already uses Azure Communication Services SMTP.
  `ben@bendewey.com` is the recipient. Outbound SMTP and inbound forwarding
  are separate services.
- GitHub Actions deploys `master` to Azure using OpenID Connect. The first
  remote workflow run completed successfully on 2026-09-25.
- GearHost has three CloudSites (`bendewey`, `nuology`, `minimunchers`), three
  databases, and domain registrations for both `bendewey.com` and
  `nuology.com`. All three CloudSites are stopped. The
  `bendewey.com` mailboxes hold about 707.5 MB; Ben confirmed their historical
  messages already reached Hotmail and need no preservation.

## Remaining GearHost exit work

1. Configure and verify ImprovMX forwarding for `ben@bendewey.com`.
2. Change the Azure DNS MX records to ImprovMX and add its required SPF
   record. Verify inbound delivery before removing GearHost mail.
3. Move domain registration to a registrar outside GearHost so renewals no
   longer bill through GearHost. This requires unlocking the domain and a
   transfer authorization code from its current reseller.
4. Resolve the `nuology.com` registration separately. It also bills through
   GearHost, and its future ownership and mail forwarding need a decision.
5. Remove the retired GearHost CloudSites and databases, then the `bendewey`
   mail service after inbound forwarding is verified. GearHost's published
   account policy says account cancellation requires an email to
   `help@gearhost.com` after all services are removed and outstanding billing
   is resolved.

Do not cancel GearHost before domain registration and inbound mail are moved;
those services still depend on the account even though the website is live on
Azure.
