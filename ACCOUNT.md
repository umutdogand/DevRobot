# Accounts
**SSH**  
	Port: 22
	Ip: 157.230.26.70
	User: root
	Pass: 123123Asd.	

**Database**  
	Port=5432	
	User=postgres Pass=postgres
	User=devrobot Pass=devrobot	
	
**Gitlab**
	Port=3000
	User=root
	Pass=123123Asd.

**Ngnix**
	Port=80
	
	
# Docker Kurulumu

yum install docker
service docker start
service docker status
chkconfig docker on

# Network

docker network create devrobot-network

# Database

docker run -d --name postgres --network bridge --network devrobot-network -e POSTGRES_PASSWORD=postgres -p 5432:5432 --expose=5432 --restart on-failure:3 -d postgres

# Gitlab

docker run --detach --hostname gitlab.example.com --publish 80:80 --publish 22:22 --name gitlab --restart always --volume /srv/gitlab/config:/etc/gitlab --volume /srv/gitlab/logs:/var/log/gitlab --volume /srv/gitlab/data:/var/opt/gitlab gitlab/gitlab-ce:latest
	
# Ngnix

# Nextcloud

docker run -d -p 8000:80 --network bridge --network devrobot-network -v /srv/nextcloud/:/var/www/html -v /srv/nextcloud/apps:/var/www/html/custom_apps -v /srv/nextcloud/config:/var/www/html/config -v /srv/nextcloud/data:/var/www/html/data nextcloud
docker run -i -t -d -p 8010:80 --name documentserver --network bridge --network devrobot-network -v /srv/onlyoffice/DocumentServer/logs:/var/log/onlyoffice -v /srv/onlyoffice/DocumentServer/data:/var/www/onlyoffice/Data  onlyoffice/documentserver
https://api.onlyoffice.com/editors/nextcloud