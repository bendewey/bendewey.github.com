#!/usr/bin/env bash
set -euo pipefail

repo_root=$(cd "$(dirname "$0")/.." && pwd)
source_root="${1:-$HOME/code/job-search/project-history}"

dotnet run --project "$repo_root/tools/ProjectInventorySync/ProjectInventorySync.csproj" -- \
  --source "$source_root" \
  --overrides "$repo_root/Content/project-presentation-overrides.json" \
  --output "$repo_root/src/BenDewey.Web/Content/projects.json"
