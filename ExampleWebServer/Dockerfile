FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY *.sln .
COPY src/ExampleWebServer/*.csproj ./src/ExampleWebServer/
RUN --mount=type=cache,target=/root/.nuget/packages dotnet restore
COPY . .
RUN --mount=type=cache,target=/root/.nuget/packages \
    dotnet publish src/ExampleWebServer/ExampleWebServer.csproj \
    -c Release -o /app/publish -p:UseAppHost=false --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
USER $APP_UID
ENV DOTNET_EnableDiagnostics=0 \
    ASPNETCORE_HTTP_PORTS=8080 \
    ASPNETCORE_ENVIRONMENT=Production
EXPOSE 8080
ENTRYPOINT ["dotnet", "ExampleWebServer.dll"]
