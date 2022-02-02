# eDukaan

## This pet project was created to learn about eCommerce.

## The earlier technology stack was inspired from

- https://github.com/dotnet-architecture/eShopOnContainers
- https://github.com/mehmetozkaya/AspnetMicroservices

## The free HTML template is from

- https://themehunt.com/item/1524993-eshopper-free-ecommerce-html-template

#### Catalog microservice which includes;

- ASP.NET Core Web API application

#### Basket microservice which includes;

- ASP.NET Web API application

#### Discount microservice which includes;

- ASP.NET **Grpc Server** application

#### Microservices Communication

- Sync inter-service **gRPC Communication**

#### Ordering Microservice

#### API Gateway Ocelot Microservice

- Implement **API Gateways with Ocelot**

#### Docker Compose establishment with all microservices on docker;

## Run The Project

- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
- [Visual Studio Code](https://code.visualstudio.com/Download/)
- [.Net Core 6 ](https://dotnet.microsoft.com/download/dotnet-core)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

### Installing

docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up --build
