# GearHost exit and domain cutover

Ben approved moving the current site to Azure, retiring the GearHost WordPress
site, and ending GearHost charges. The new portfolio does not depend on a
WordPress content migration or a rollback copy.

## Current dependencies

- `bendewey.com` is registered through Tucows with GearHost as reseller;
  registration expires on 2027-01-14. GearHost nameservers are delegated at the
  registrar and serve the live website and mail records.
- An Azure DNS zone for `bendewey.com` is staged in `Default-Web-EastUS`. Its
  apex A record points to the `bendewey-blog` App Service inbound IP, `www`
  points directly to its Azure hostname, and both `asuid` verification TXT
  records are present.
- The staged Azure zone temporarily preserves `mail2.gearhost.com` as the MX
  destination. It must be changed when Ben's ImprovMX forwarding is active.
- Outbound site contact mail already uses Azure Communication Services SMTP.
  `ben@bendewey.com` is the recipient. Outbound SMTP and inbound forwarding
  are separate services.

## Remaining cutover work

1. Configure and verify ImprovMX forwarding for `ben@bendewey.com`.
2. Change the staged Azure DNS MX records to ImprovMX and add its required SPF
   record. Verify both against ImprovMX's domain setup instructions.
3. Sign in to GearHost's registrar controls and delegate the domain to the four
   nameservers assigned to the Azure DNS zone. Azure DNS is a DNS host, not a
   domain registrar.
4. Bind `bendewey.com` and `www.bendewey.com` to `bendewey-blog`, issue and bind
   Azure-managed TLS certificates, and verify HTTPS and the redirect from
   `www` to the apex domain.
5. Move domain registration to a registrar outside GearHost so renewals no
   longer bill through GearHost. This requires unlocking the domain and a
   transfer authorization code from its current reseller.
6. Destroy the old GearHost CloudSite, database, and mail service after the
   website and ImprovMX are verified. GearHost's published account policy says
   account cancellation requires an email to `help@gearhost.com` after all
   services are removed and outstanding billing is resolved.

Do not cancel GearHost before the domain transfer and inbound mail are working;
those services still depend on the account even though the replacement website
is already live on Azure.
