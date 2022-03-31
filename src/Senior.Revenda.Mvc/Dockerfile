# escape=`

FROM mcr.microsoft.com/dotnet/framework/sdk:4.8-windowsservercore-ltsc2019 AS build

## Set Working Directory
WORKDIR /app

## Copy all working directory files to container path /app
COPY ./ .
# COPY . .

## Nuget restore solution file
RUN nuget restore Revenda.sln;

## MSBuild solutionfile
RUN msbuild 'Revenda.sln' /p:configuration='Release' /p:platform='Any CPU' `
    /p:VisualStudioVersion=16.0 

## 2nd stage begins
FROM mcr.microsoft.com/windows/servercore/iis

## Set IIS Working Directory
WORKDIR /inetpub/wwwroot

## Copy files from previous stage
COPY --from=build /app/src/Senior.Revenda.Mvc/. ./

## Expose port 80
EXPOSE 4200