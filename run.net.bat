@ECHO OFF

SET project="Zuul"
SET framework="netcoreapp3.1"
SET config="Release"

dotnet build %project%/%project%.csproj --configuration "%config%"
cls
dotnet exec %project%/bin/%config%/%framework%/%project%.dll
dotnet clean %project%/%project%.csproj --configuration "%config%"

@REM PAUSE
