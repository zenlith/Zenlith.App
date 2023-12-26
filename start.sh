dotnet database update --project Zenlith.Migrations -- Integrated Security=false;Pooling=false;Data Source=.;Initial Catalog=zenlith;User ID=zenlith;Password=zenlith;TrustServerCertificate=True
echo "Database updated"
dotnet Zenlith.App.Blazor.Server.dll