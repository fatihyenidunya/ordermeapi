FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ordermeapi/ordermeapi.csproj", "ordermeapi/"]
RUN dotnet restore "ordermeapi/ordermeapi.csproj"
COPY . .
WORKDIR "/src/ordermeapi"
RUN dotnet build "ordermeapi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ordermeapi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ordermeapi.dll"]