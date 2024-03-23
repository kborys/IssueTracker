# IssueTracker

## Development

### Frontend Setup

```bash
npm install
# Automatically minify tailwindcss
npx tailwindcss -i src/IssueTracker.Web/wwwroot/css/site.css -o src/IssueTracker.Web/wwwroot/css/site.min.css --watch
```

### Backend Setup

```bash
# Add ef migration
dotnet ef migrations add MigrationName -p .\src\IssueTracker.Web\ -o Data\Migrations
# Apply ef migration
dotnet ef database update --project .\src\IssueTracker.Web\IssueTracker.Web.csproj
```

## Technologies

1. ASP.NET 8.0
2. TailwindCSS