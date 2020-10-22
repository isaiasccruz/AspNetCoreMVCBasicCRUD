FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY PageBasicCRUDAspNETMVCAuctionApp/PageBasicCRUDAspNETMVCAuctionApp.csproj PageBasicCRUDAspNETMVCAuctionApp/
COPY Infra.UtilsCore/Infra.UtilsCore.csproj Infra.UtilsCore/
COPY AplicacaoCore/AplicacaoCore.csproj AplicacaoCore/
COPY Infra.ContextoCore/Infra.ContextoCore.csproj Infra.ContextoCore/
COPY DominioCore/DominioCore.csproj DominioCore/
COPY Infra.CrossCutting.IoCCore/Infra.CrossCutting.IoCCore.csproj Infra.CrossCutting.IoCCore/
COPY Infra.RepositorioCore/Infra.RepositorioCore.csproj Infra.RepositorioCore/
RUN dotnet restore PageBasicCRUDAspNETMVCAuctionApp/PageBasicCRUDAspNETMVCAuctionApp.csproj
COPY . .
WORKDIR /src/PageBasicCRUDAspNETMVCAuctionApp
RUN dotnet build PageBasicCRUDAspNETMVCAuctionApp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PageBasicCRUDAspNETMVCAuctionApp.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PageBasicCRUDAspNETMVCAuctionApp.dll"]
