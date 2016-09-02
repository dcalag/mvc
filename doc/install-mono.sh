#!/bin/bash
#http://www.mono-project.com/docs/getting-started/install/linux/#debian-ubuntu-and-derivatives
#instalar mono:
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
echo "deb http://download.mono-project.com/repo/debian wheezy main" | sudo tee /etc/apt/sources.list.d/mono-xamarin.list
sudo apt-get update
sudo apt-get install mono-complete
sudo apt-get install monodevelop
sudo apt-get install mono-xsp4

#instalar libgdiplus  (Debian 8.0 and later, NOT Ubuntu)
echo "deb http://download.mono-project.com/repo/debian wheezy-libjpeg62-compat main" | sudo tee -a /etc/apt/sources.list.d/mono-xamarin.list
sudo apt-get update
sudo apt-get install libgdiplus