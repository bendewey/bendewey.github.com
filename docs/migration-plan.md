# Legacy migration plan

The live site is the GearHost-hosted WordPress site. This repository was not
its historical source. Do not alter or cancel GearHost while recovery is in
progress.

An additional public source is [bendewey.wordpress.com](https://bendewey.wordpress.com/),
whose content Ben made available for this work on September 18, 2026. Its visible
archive spans 2008–2010 and ends with a move announcement to BenDewey.com. Include
it in the ledger alongside the later self-hosted site; do not treat it as a
complete backup of GearHost. Preserve publication dates and source provenance,
reconcile duplicates, and verify linked assets during migration.

## Recovery sequence

1. Download GearHost site files through FTP and store a separate backup.
2. Export the production MySQL database and store it separately from the code
   repository.
3. Inventory WordPress pages, posts, media, categories, tags and URLs from the
   exports.
4. Compare those exports with the retained historical snapshot at
   `/Volumes/TOSHIBA EXT/Development/BenDewey.com` when available.
5. Create a migration ledger for every discovered URL.
6. Classify each item as migrate, archive, redirect or retire.
7. Implement and test redirects before DNS cutover.

## Migration ledger fields

| Field | Meaning |
| --- | --- |
| Legacy URL | Exact incoming path and hostname behavior. |
| Title/type | Page, post, media, download or application. |
| Disposition | Migrate, archive, redirect or retire. |
| New destination | Target route or explicit archival location. |
| Owner/approval | Who verified content and sharing suitability. |
| Notes | Dates, risk, dependencies and asset handling. |

Never commit database exports, FTP credentials, WordPress secrets or unreviewed
production content into this repository.
