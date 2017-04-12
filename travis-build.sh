#!/bin/bash

RELEASE="$TRAVIS_TAG.$TRAVIS_BUILD_NUMBER"
PROJECT=$TRAVIS_BUILD_DIR/src/one-token-please.csproj
CONFIG=Release
WIN_ENV=win10-x64
OSX_ENV=osx.10.11-x64
BUILD_PATH=$TRAVIS_BUILD_DIR/build/$CONFIG
WIN_PATH="$BUILD_PATH/$WIN_ENV/"
OSX_PATH="$BUILD_PATH/$OSX_ENV/"
WIN_FILENAME="one-token-please_$RELEASE_$WIN_ENV.zip"
OSX_FILENAME="one-token-please_$RELEASE_$OSX_ENV.zip"


if hash dotnet 2>/dev/null; then
    dotnet restore 
    dotnet publish $PROJECT -c $CONFIG -r $WIN_ENV --output $WIN_PATH
    dotnet publish $PROJECT -c $CONFIG -r $OSX_ENV --output $OSX_PATH
else 
    echo "dotnet command not found"
fi

if hash zip 2>/dev/null; then
    zip -r $BUILD_PATH/$WIN_FILENAME $WIN_PATH
    zip -r $BUILD_PATH/$OSX_FILENAME $OSX_PATH
else
  echo "zip command not found"
fi