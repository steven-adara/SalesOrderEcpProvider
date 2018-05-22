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
ARG SALES_ORDER_ECP_PROVIDER_SALES_ORDER_API_ADDRESS="http://192.168.99.100:5000/api/sales-orders"
ENV SALES_ORDER_ECP_PROVIDER_SALES_ORDER_API_ADDRESS=$SALES_ORDER_ECP_PROVIDER_SALES_ORDER_API_ADDRESS
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SalesOrderEcpProvider.dll"]
