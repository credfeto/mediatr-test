FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Credfeto.Mediatr.Cmd/Credfeto.Mediatr.Cmd.csproj", "Credfeto.Mediatr.Cmd/"]
RUN dotnet restore "Credfeto.Mediatr.Cmd/Credfeto.Mediatr.Cmd.csproj"
COPY . .
WORKDIR "/src/Credfeto.Mediatr.Cmd"
RUN dotnet build "Credfeto.Mediatr.Cmd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Credfeto.Mediatr.Cmd.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Credfeto.Mediatr.Cmd.dll"]
