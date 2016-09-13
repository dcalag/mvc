#/bin/bash
server=daniel@test
ssh $server 'rm -R ~/publish'
scp -r ./publish $server:~/publish
scp *.sh $server:~/
