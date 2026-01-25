## Team Workflow (Phase 1)

- Default integration branch: `dev`
- Do NOT commit directly to `main`
- Create feature branches and open PRs into `dev`
- Branch naming:
  - feature/<short-desc>
  - data/<short-desc>
  - infra/<short-desc>

### Pull Request Checklist
- `dotnet build` passes
- `dotnet test` executed (note failing tests in PR)
- No changes to automated test code
- Controllers use DTOs only (no EF entities in I/O)
- Routes and status codes match assignment spec

After Phase 1 is stable and deployment works, we will merge `dev` → `main`.
