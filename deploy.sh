#!/bin/bash
sudo /etc/init.d/apache2 stop
rm -r /var/www/mvc
mkdir /var/www/mvc
cp -a publish/. /var/www/mvc/
sudo /etc/init.d/apache2 start
