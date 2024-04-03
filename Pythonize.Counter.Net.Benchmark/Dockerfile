FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Pythonize.Counter.Net.Benchmark/Pythonize.Counter.Net.Benchmark.csproj", "Pythonize.Counter.Net.Benchmark/"]
RUN dotnet restore "Pythonize.Counter.Net.Benchmark/Pythonize.Counter.Net.Benchmark.csproj"
COPY . .
WORKDIR "/src/Pythonize.Counter.Net.Benchmark"
RUN dotnet build "Pythonize.Counter.Net.Benchmark.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pythonize.Counter.Net.Benchmark.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pythonize.Counter.Net.Benchmark.dll"]
