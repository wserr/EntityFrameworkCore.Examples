FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EntityFramework.Examples.Web/EntityFramework.Examples.Web.csproj", "EntityFramework.Examples.Web/"]
RUN dotnet restore "EntityFramework.Examples.Web/EntityFramework.Examples.Web.csproj"
COPY . .
WORKDIR "/src/EntityFramework.Examples.Web"
RUN dotnet build "EntityFramework.Examples.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EntityFramework.Examples.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EntityFramework.Examples.Web.dll"]
