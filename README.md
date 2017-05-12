# one-token-please
A cross platform .NET Core CLI app to get an Auth token. Right now it just gets one from Azure Active Directory using an application key

[![Build Status](https://travis-ci.org/StephenGilboy/one-token-please.svg?branch=master)](https://travis-ci.org/StephenGilboy/one-token-please)

## How to use it

* If you're on OSX you'll need to install the pre-requisites for dotnet core. https://www.microsoft.com/net/core#macos 
* Download the latest release for your system https://github.com/StephenGilboy/one-token-please/releases (Note: Its 20MB because it contains the full .NET Framework so you don't need to install it)
* Run it providing the parameters listed below

## Parameters
`-s` Auth Service. Defaults to 'aad' which is Azure Active Directory

`-c` ClientID. This is a GUID that you'll get from the AAD portal

`-k` AppKey. This is the key that is generated when adding an app in the AAD Portal.

`-r` Resource. https://yourcompany.onmicrosoft.com/YourApplication

`-a` Authority. https://login.microsoftonline.com/yourcompany.onmicrosoft.com

