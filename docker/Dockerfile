#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PorphumWeb.Blazor/PorphumWeb.Blazor.csproj", "PorphumWeb.Blazor/"]
COPY ["General/General.csproj", "General/"]
COPY ["PorphumReferenceBook.Logic/PorphumReferenceBook.Logic.csproj", "PorphumReferenceBook.Logic/"]
COPY ["PorphumSales.Logic/PorphumSales.Logic.csproj", "PorphumSales.Logic/"]
COPY ["PorphumWeb.Logic/PorphumWeb.Logic.csproj", "PorphumWeb.Logic/"]
RUN dotnet restore "PorphumWeb.Blazor/PorphumWeb.Blazor.csproj"
COPY . .
WORKDIR "/src/PorphumWeb.Blazor"
RUN dotnet build "PorphumWeb.Blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PorphumWeb.Blazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PorphumWeb.Blazor.dll"]