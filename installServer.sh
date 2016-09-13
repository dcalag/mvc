#!/bin/bash

# http://www.mono-project.com/docs/getting-started/install/linux/#debian-ubuntu-and-derivatives
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
#mono:
echo "deb http://download.mono-project.com/repo/debian wheezy main" | sudo tee /etc/apt/sources.list.d/mono-xamarin.list
#libgdiplus:
echo "deb http://download.mono-project.com/repo/debian wheezy-libjpeg62-compat main" | sudo tee -a /etc/apt/sources.list.d/mono-xamarin.list
#mod_mono:
echo "deb http://download.mono-project.com/repo/debian wheezy-apache24-compat main" | sudo tee -a /etc/apt/sources.list.d/mono-xamarin.list
sudo apt-get update
sudo apt-get install apache2
sudo apt-get install libapache2-mod-mono mono-apache-server4

#detener server para hacer cambios.
sudo /etc/init.d/apache2 stop
app=mvc
# descargar un archivo de configuración de la herramienta online:
# http://go-mono.com/config-mod-mono/
# y copiarlo a /etc/apache2/conf-available
# Nota: antes de copiarlo checar el path 'MonoServerPath' y establecerlo como:
# MonoServerPath <app> "/usr/bin/mod-mono-server4"
sudo cp $app.conf /etc/apache2/conf-available
# habilitar la configuración:
sudo a2enconf $app.conf
# habilitar el módulo de mod_mono:
sudo a2enmod mod_mono
#fix bug mono:
sudo mkdir /etc/mono/registry
sudo chmod 766 /etc/mono/registry
#reiniciar servidor apache2 para que surtan efecto los cambios:
sudo /etc/init.d/apache2 start
