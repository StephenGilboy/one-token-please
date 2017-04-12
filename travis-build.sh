#!/bin/bash

RELEASE="$TRAVIS_TAG.$TRAVIS_BUILD_NUMBER"
PROJECT=$TRAVIS_BUILD_DIR/src/one-token-please.csproj
CONFIG=Release
WIN_ENV=win10-x64
OSX_ENV=osx.10.11-x64
BUILD_PATH=$TRAVIS_BUILD_DIR/build/$CONFIG
WIN_PATH="$BUILD_PATH/$WIN_ENV/"
OSX_PATH="$BUILD_PATH/$OSX_ENV/"
FILENAME_PREFIX="one-token-please"
WIN_FILENAME="${FILENAME_PREFIX}_${RELEASE}_${WIN_ENV}.zip"
OSX_FILENAME="${FILENAME_PREFIX}_${RELEASE}_${OSX_ENV}.zip"


if hash dotnet 2>/dev/null; then
    dotnet restore 
    dotnet publish $PROJECT -c $CONFIG -r $WIN_ENV --output $WIN_PATH
    dotnet publish $PROJECT -c $CONFIG -r $OSX_ENV --output $OSX_PATH
else 
    echo "dotnet command not found"
    exit 1
fi

if hash zip 2>/dev/null; then
    cd $BUILD_PATH
    zip -r ./$WIN_FILENAME $WIN_ENV
    zip -r ./$OSX_FILENAME $OSX_ENV
else
  echo "zip command not found"
  exit 1
fi