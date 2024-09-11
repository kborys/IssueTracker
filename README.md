# IssueTracker

## How to run

1. Make sure docker engine is up
2. Run docker compose

```bash
docker compose up
```

3. Run the IssueTracker.Web

## Development

### Frontend setup

```bash
npm install
# Automatically minify tailwindcss
npx tailwindcss -i src/IssueTracker.Web/wwwroot/css/site.css -o src/IssueTracker.Web/wwwroot/css/site.min.css --watch
```

### Adding migrations

```bash 
cd src/<ProjectContaingTheDbContext>
dotnet ef migrations add <MigrationName> --startup-project ..\IssueTracker.Web\ -o ./Dal/Migrations --context <DbContextName>
```

### Applying migrations

Migrations are applied automatically in IssueTracker.Web.Services.AppInitializer

## Technologies

1. ASP.NET MVC 8.0
2. ASP.NET Core Identity
3. EF Core
4. PostgreSQL
5. AutoMapper
6. FluentValidation
7. TailwindCSS