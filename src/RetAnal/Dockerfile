FROM mcr.microsoft.com/dotnet/sdk:7.0 AS api-build-env
WORKDIR /app

COPY ["RetAnal.Api/RetAnal.Api.csproj", "RetAnal.Api/"]
COPY ["RetAnal.Core/RetAnal.Core.csproj", "RetAnal.Core/"]
COPY ["RetAnal.Data/RetAnal.Data.csproj", "RetAnal.Data/"]

RUN dotnet restore RetAnal.Api/RetAnal.Api.csproj

COPY . .
WORKDIR /app/RetAnal.Api
RUN dotnet publish RetAnal.Api.csproj -c Release -o ../out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=api-build-env /app/out .
ENTRYPOINT ["dotnet", "RetAnal.Api.dll"]
