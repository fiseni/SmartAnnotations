#!/bin/bash

dotnet test //p:CollectCoverage=true //p:CoverletOutputFormat=cobertura
$USERPROFILE/.nuget/packages/reportgenerator/4.8.7/tools/net5.0/ReportGenerator.exe -reports:tests/SmartAnnotations.UnitTests/coverage.cobertura.xml -targetdir:tests/coverage
