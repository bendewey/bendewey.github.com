---
name: project-inventory
description: Plan, write, review, or update BenDewey.com project inventory and case-study content using the canonical job-search project history. Use when selecting portfolio projects, deciding public versus shared-password detail, or verifying project claims for the BenDewey.com site.
---

# Project inventory

Use this skill for BenDewey.com project and case-study work. It keeps the
website aligned with Ben's canonical consulting project inventory while
enforcing the public-versus-full sharing model.

## Canonical sources

1. Read `/Users/bendewey/code/job-search/project-history/index.md` first.
2. Read the linked record for every project being discussed or edited.
3. Read [the repository integration guide](../../../docs/project-inventory-integration.md)
   before designing a new project data model or publishing flow.
4. Use [the content plan](../../../docs/content-plan.md) when choosing initial
   work.

The job-search inventory is the factual source of truth. If a project fact is
new or needs correction, update its canonical project record in the job-search
workspace as part of the same work; do not silently make the website a competing
record.

## Workflow

1. Identify the requested audience and access layer: public or shared-password
   full inventory.
2. Extract only source-backed role, scope, date, technology and outcome facts.
3. Draft a public-safe label and description. Use a generic or anonymized label
   whenever the record lacks an explicit public-sharing decision.
4. Add fuller detail only when Ben has approved it for the shared-password
   audience.
5. Mark uncertain facts as open content questions rather than filling gaps.
6. Keep public and full fields visibly separate in the content model.

## Current selection guidance

- Start with CapHub, Proskauer, the Power BI cluster and launched ThriftTrack.
- Treat CSAA NextGen and WME Pulse as protected or later material requiring
  careful review.
- Ben is Nuology's founder. Only ThriftTrack is confirmed launched; do not
  imply that another Nuology product has launched.
- Nuology.com is the prospective-client destination. BenDewey.com provides a
  concise founder/product bridge for an employer audience.

## Publishing safeguards

- Never invent metrics, dates, outcomes, client permission, shipped scope or
  technical implementation detail.
- Never expose credentials, PII, trade secrets, proprietary workflows or
  material restricted by confidentiality obligations.
- A shared password is a convenience gate, not permission to distribute truly
  confidential material.
- Keep the password and session-signing secret in Azure App Service settings,
  never in repository content or examples.

## Final check

Before marking project content ready, verify that:

- every claim is backed by the canonical record or an explicitly noted Ben
  approval;
- anonymous pages disclose only public-safe text;
- fuller content belongs to the approved shared-password audience;
- status language is accurate, especially product launch status;
- the project still supports the employer-facing story of the site.
