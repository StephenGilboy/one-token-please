# one-token-please
A cross platform .NET Core CLI app to get an Auth token. Right now it just gets one from Azure Active Directory using an application key

[![Build Status](https://travis-ci.org/StephenGilboy/one-token-please.svg?branch=master)](https://travis-ci.org/StephenGilboy/one-token-please)

## How to use it

* Install Dotnet Core, if you haven't already. https://www.microsoft.com/net/core
* `dotnet build`
* `cd bin/Debug/netcoreapp1.1/` 
* `dotnet one-token-please.dll -s aad -c <ClientId> -k <appKey> -r <resource> -a <authority>`
* Releases coming soon

## Parameters
`-s` Auth Service. Defaults to 'aad' which is Azure Active Directory

`-c` ClientID. This is a GUID that you'll get from the AAD portal

`-k` AppKey. This is the key that is generated when adding an app in the AAD Portal.

`-r` Resource. https://yourcompany.onmicrosoft.com/YourApplication

`-a` Authority. https://login.microsoftonline.com/yourcompany.onmicrosoft.com

