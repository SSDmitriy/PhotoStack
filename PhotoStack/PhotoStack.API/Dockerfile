#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /src
COPY ["PhotoStack.API/PhotoStack.API.csproj", "PhotoStack.API/"]
RUN dotnet restore "PhotoStack.API/PhotoStack.API.csproj"
COPY . .
WORKDIR "/src/PhotoStack.API"
RUN dotnet build "PhotoStack.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PhotoStack.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhotoStack.API.dll"]