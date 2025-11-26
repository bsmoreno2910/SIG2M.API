# Utiliza a imagem ASP.NET do .NET 9
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

# Expõe as portas usadas pela API
EXPOSE 8080
EXPOSE 8081

# Usuário padrão de execução
ENV APP_UID=1654

# ================================
#  ESTÁGIO 1 – BUILD
# ================================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia os arquivos do projeto
COPY ["SIG2M.API.csproj", "./"]
RUN dotnet restore "./SIG2M.API.csproj"

# Copia o restante dos arquivos
COPY . .

# Compila
RUN dotnet build "./SIG2M.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ================================
#  ESTÁGIO 2 – PUBLISH
# ================================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SIG2M.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ================================
#  ESTÁGIO 3 – FINAL (com VSDBG)
# ================================
FROM base AS final

# ⚠️ Mudar para root para instalar vsdbg e criar diretórios
USER root

# ---- Instalação do vsdbg (necessário para Debug Remoto no VS 2022)
RUN apt-get update \
    && apt-get install -y curl unzip \
    && mkdir -p /vsdbg \
    && curl -sSL https://aka.ms/getvsdbgsh -o /vsdbg/getvsdbg.sh \
    && chmod +x /vsdbg/getvsdbg.sh \
    && /vsdbg/getvsdbg.sh -v latest -l /vsdbg \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

# ---- Diretórios para data protection e logs
RUN mkdir -p /data/dataprotection-keys /data/logs && chmod -R 777 /data

# Retorna para o usuário configurado
USER $APP_UID

WORKDIR /app

# Copia os arquivos publicados
COPY --from=publish /app/publish .

# Comando final
ENTRYPOINT ["dotnet", "SIG2M.API.dll"]
