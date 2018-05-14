FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY SalesOrderEcpProvider.sln ./
COPY SalesOrderEcpProvider/SalesOrderEcpProvider.csproj SalesOrderEcpProvider/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/SalesOrderEcpProvider
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
ARG SOP_API_URL="http://192.168.99.101:5000/api/import"
ARG SOP_API_HC_URL="http://192.168.99.101:5000/hc"
ENV SOP_API_URL=$SOP_API_URL
ENV SOP_API_HC_URL=$SOP_API_HC_URL
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SalesOrderEcpProvider.dll"]
