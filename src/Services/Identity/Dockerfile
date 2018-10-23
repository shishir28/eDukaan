FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app


FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY . .

WORKDIR /src/src/Services/Identity

RUN dotnet restore  -nowarn:msb3202,nu1503

WORKDIR /src/src/Services/Identity/Monad.EDukaan.Service.Identity.Web.Api/

RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Monad.EDukaan.Service.Identity.Web.Api.dll"]

EXPOSE 9001