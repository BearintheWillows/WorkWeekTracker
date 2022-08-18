FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WWTApi/WWTApi.csproj", "WWTApi/"]
RUN dotnet restore "WWTApi/WWTApi.csproj"
COPY . .
WORKDIR "/src/WWTApi"
RUN dotnet build "WWTApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WWTApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WWTApi.dll"]
