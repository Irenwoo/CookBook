FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Presentation/CookBook.WebHost/CookBook.WebHost.csproj", "Presentation/CookBook.WebHost/"]
COPY ["Domain/CookBook.Domain/CookBook.Domain.csproj", "Domain/CookBook.Domain/"]
COPY ["Domain/CookBook.ValueObjects/CookBook.ValueObjects.csproj", "Domain/CookBook.ValueObjects/"]
COPY ["Domain/CookBook.Domain.Repositories.Abstractions/CookBook.Domain.Repositories.Abstractions.csproj", "Domain/CookBook.Domain.Repositories.Abstractions/"]
COPY ["Infrastructure/CookBook.Infrastructure/CookBook.Infrastructure.csproj", "Infrastructure/CookBook.Infrastructure/"]
RUN dotnet restore "Presentation/CookBook.WebHost/CookBook.WebHost.csproj"
COPY . .
WORKDIR "/src/Presentation/CookBook.WebHost"
RUN dotnet build "CookBook.WebHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CookBook.WebHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CookBook.WebHost.dll"]
