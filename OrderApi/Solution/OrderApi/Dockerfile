#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS publish
WORKDIR /src
COPY . .
#COPY ["Solution/OrderApi/OrderApi.csproj", "Solution/OrderApi/"]
#COPY ["Solution/OrderApi.Application/OrderApi.Application.csproj", "Solution/OrderApi.Application/"]
#COPY ["Solution/OrderApi.Domain/OrderApi.Domain.csproj", "Solution/OrderApi.Domain/"]
#COPY ["Solution/OrderApi.Infrastructure.Data/OrderApi.Infrastructure.Data.csproj", "Solution/OrderApi.Infrastructure.Data/"]
#COPY ["Solution/OrderApi.Infrastructure.Messaging.Receive/OrderApi.Infrastructure.Messaging.Receive.csproj", "Solution/OrderApi.Infrastructure.Messaging.Receive/"]
RUN dotnet restore "Solution/OrderApi/OrderApi.csproj"
WORKDIR "/src/Solution/OrderApi"
RUN dotnet publish "OrderApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderApi.dll"]