FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WWTClient/WWTClient.csproj", "WWTClient/"]
RUN dotnet restore "WWTClient/WWTClient.csproj"
COPY . .
WORKDIR "/src/WWTClient"
RUN dotnet build "WWTClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WWTClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WWTClient.dll"]
