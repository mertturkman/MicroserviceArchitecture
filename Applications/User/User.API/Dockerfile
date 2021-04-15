#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Applications/User/User.API/User.API.csproj", "Applications/User/User.API/"]
COPY ["CrossCutting/EventBus/EventBus.csproj", "CrossCutting/EventBus/"]
COPY ["CrossCutting/Extensions/Extensions.csproj", "CrossCutting/Extensions/"]
COPY ["CrossCutting/Authentication/Authentication.csproj", "CrossCutting/Authentication/"]
COPY ["CrossCutting/Events/Events.csproj", "CrossCutting/Events/"]
COPY ["Applications/User/User.Infrastructure/User.Infrastructure.csproj", "Applications/User/User.Infrastructure/"]
COPY ["Applications/User/User.Domain/User.Domain.csproj", "Applications/User/User.Domain/"]
COPY ["CrossCutting/Middleware/Middleware.csproj", "CrossCutting/Middleware/"]
COPY ["Applications/User/User.Application/User.Application.csproj", "Applications/User/User.Application/"]
RUN dotnet restore "Applications/User/User.API/User.API.csproj"
COPY . .
WORKDIR "/src/Applications/User/User.API"
RUN dotnet build "User.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "User.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.API.dll"]