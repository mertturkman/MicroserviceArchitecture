#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Applications/User/User.Identity/User.Identity.csproj", "Applications/User/User.Identity/"]
COPY ["CrossCutting/Authentication/Authentication.csproj", "CrossCutting/Authentication/"]
COPY ["Applications/User/User.Infrastructure/User.Infrastructure.csproj", "Applications/User/User.Infrastructure/"]
COPY ["Applications/User/User.Domain/User.Domain.csproj", "Applications/User/User.Domain/"]
COPY ["CrossCutting/Events/Events.csproj", "CrossCutting/Events/"]
COPY ["CrossCutting/EventBus/EventBus.csproj", "CrossCutting/EventBus/"]
COPY ["Applications/User/User.Application/User.Application.csproj", "Applications/User/User.Application/"]
RUN dotnet restore "Applications/User/User.Identity/User.Identity.csproj"
COPY . .
WORKDIR "/src/Applications/User/User.Identity"
RUN dotnet build "User.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "User.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.Identity.dll"]