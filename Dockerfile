FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY ./AplicacaoCore/*.csproj ./AplicacaoCore/
COPY ./DominioCore/*.csproj ./DominioCore/
COPY ./Infra.ContextoCore/*.csproj ./Infra.ContextoCore/
COPY ./Infra.CrossCutting.IoCCore/*.csproj ./Infra.CrossCutting.IoCCore/
COPY ./Infra.RepositorioCore/*.csproj ./Infra.RepositorioCore/
COPY ./Infra.UtilsCore/*.csproj ./Infra.UtilsCore/
COPY ./PageBasicCRUDAspNETMVCAuctionApp/*.csproj ./PageBasicCRUDAspNETMVCAuctionApp/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image

# runtime para broker console e aspnet para as aplicações asp.net core

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
#COPY --from=build-env /app/output .
#COPY --from=build-env /app/out .
COPY --from=build-env /app/ .
ENTRYPOINT ["dotnet", "PageBasicCRUDAspNETMVCAuctionApp.dll"]

