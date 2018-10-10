FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 61452
EXPOSE 44348

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["MSUser/MSUser.csproj", "MSUser/"]
RUN dotnet restore "MSUser/MSUser.csproj"
COPY . .
WORKDIR "/src/MSUser"
RUN dotnet build "MSUser.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MSUser.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MSUser.dll"]