#!/bin/zsh

# Clean up
rm -rf obj bin
dotnet clean

# Build
dotnet build -c Release

# Copy DLL to target
cp /Users/danijeljw/Projects/repasscloud/lunavpn/LunaApiVultr/bin/Release/net6.0/LunaApiVultr.dll /Users/danijeljw/Projects/repasscloud/lunavpn/VultrApi/
