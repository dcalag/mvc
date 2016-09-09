#!/bin/bash
mdtool build mvc.sln
dest=./publish
rm -r $dest
mkdir $dest
cp -a bin/. $dest/bin/
cp -a Content/. $dest/Content/
cp -a Scripts/. $dest/Scripts/
cp -a Views/. $dest/Views/
cp Global.asax $dest/Global.asax
cp Global.asax.cs $dest/Global.asax.cs
cp Web.config $dest/Web.config
cp packages.config $dest/packages.config
