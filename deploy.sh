#!/bin/bash
sudo /etc/init.d/apache2 stop
./publish.sh
sudo rm -r /var/www/mvc
sudo mkdir /var/www/mvc
sudo cp -a publish/. /var/www/mvc/
sudo /etc/init.d/apache2 start
