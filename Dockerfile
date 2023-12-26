FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY . ./docker-size-test
WORKDIR /docker-size-test/
RUN dotnet restore
RUN dotnet build -c Release -o output
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
COPY --from=build /docker-size-test/output .
ENTRYPOINT ["dotnet", "docker-size-test.dll"]