#!/bin/bash

# Build docker image from ezshop.accounts 
docker build -t ezshop.accounts:dev ./ezShop.accounts/

# Build docker image from EzShop.Orders, first compile and publish the .net app
dotnet build -c Release ./EzShop.Orders/ && \
dotnet publish -c Release ./EzShop.Orders/ && \
docker build -t ezshop.orders:dev ./EzShop.Orders/
