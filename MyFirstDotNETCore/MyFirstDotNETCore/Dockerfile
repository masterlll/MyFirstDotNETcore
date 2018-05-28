FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 55935
EXPOSE 44395

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY MyFirstDotNETCore/MyFirstDotNETCore.csproj MyFirstDotNETCore/
RUN dotnet restore MyFirstDotNETCore/MyFirstDotNETCore.csproj
COPY . .
WORKDIR /src/MyFirstDotNETCore
RUN dotnet build MyFirstDotNETCore.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MyFirstDotNETCore.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MyFirstDotNETCore.dll"]
