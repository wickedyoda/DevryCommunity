﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

# the following folder must exist because it is part of the configuration
RUN mkdir -p /app/Data/Configs
RUN chmod --recursive 777 /app/Data
RUN chmod --recursive +x /app/Data

#image updates
RUN apt-get update
#RUN apt-get upgrade -y
#RUN apt-get autoremove -y
#RUN apt-get purge -y

# Python Snippet Scanner Requires the following items to be installed
#RUN apt-get install -y python3-pip
#RUN pip3 install prospector[with_everything]

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
COPY DevryBot/DevryBot.csproj .
RUN dotnet restore "DevryBot.csproj"

WORKDIR "/src/DevryBot"
RUN dotnet build "DevryBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevryBot/DevryBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevryBot.dll"]
