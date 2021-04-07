#!/bin/bash

./clean.sh contents
dotnet clean
dotnet build
