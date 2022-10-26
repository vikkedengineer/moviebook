#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MovieBook.App.Api/MovieBook.App.Api.csproj", "MovieBook.App.Api/"]
RUN dotnet restore "MovieBook.App.Api/MovieBook.App.Api.csproj"
COPY . .
WORKDIR "/src/MovieBook.App.Api"
RUN dotnet build "MovieBook.App.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieBook.App.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieBook.App.Api.dll"]