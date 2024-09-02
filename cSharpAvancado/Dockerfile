FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["cSharpAvancado/cSharpAvancado.csproj", "cSharpAvancado/"]
RUN dotnet restore "cSharpAvancado/cSharpAvancado.csproj"
COPY . .
WORKDIR "/src/cSharpAvancado"
RUN dotnet build "cSharpAvancado.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "cSharpAvancado.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cSharpAvancado.dll"]
