FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ecommerce-catalog.csproj", "./"]
RUN dotnet restore "ecommerce-catalog.csproj"
COPY . .

RUN dotnet publish "ecommerce-catalog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ecommerce-catalog.dll"]
