FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EntityFrameworkCore.Examples.Web/EntityFrameworkCore.Examples.Web.csproj", "EntityFrameworkCore.Examples.Web/"]
COPY ["EntityFrameworkCore.Examples.Application/EntityFrameworkCore.Examples.Application.csproj", "EntityFrameworkCore.Examples.Application/"]
COPY ["EntityFrameworkCore.Examples.Persistence/EntityFrameworkCore.Examples.Persistence.csproj", "EntityFrameworkCore.Examples.Persistence/"]
RUN dotnet restore "EntityFrameworkCore.Examples.Web/EntityFrameworkCore.Examples.Web.csproj"
COPY . .
WORKDIR "/src/EntityFrameworkCore.Examples.Web"
RUN dotnet build "EntityFrameworkCore.Examples.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EntityFrameworkCore.Examples.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EntityFrameworkCore.Examples.Web.dll"]
