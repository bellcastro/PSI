ARG email_user=0
ARG email_password=0

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
ENV SEND_EMAIL=$email_user
ENV SEND_EMAIL_PASSWORD=$email_password
RUN dotnet restore 
RUN dotnet build --no-restore -c Release -o /app

RUN cp /src/Nutrimaisdb.T /app/Nutrimais.db && cp /src/Nutrimaisdb-wal.T /app/Nutrimais.db-wal

FROM build AS publish
ENV SEND_EMAIL=$email_user
ENV SEND_EMAIL_PASSWORD=$email_password
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet NutriMais.dll

#heroku container:push web -a nutri-mais
#heroku container:release web -a nutri-mais