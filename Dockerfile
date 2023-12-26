FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY . ./workdir
WORKDIR /workdir/
RUN dotnet restore
RUN dotnet build -c Release -o output
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
COPY start.sh /bin/start.sh
COPY --from=build /workdir/output .
ENTRYPOINT ["start.sh"]