#!/bin/bash
microk8s.docker build -t ezshop.accounts:v1 ./ezShop.accounts/
microk8s.docker build -t ezshop.orders:v1 ./EzShop.Orders/

