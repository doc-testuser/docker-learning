Integration between Docker and Jenkins

docker run -d -p 8080:8080 -p 50000:50000 jenkins/jenkins

or

docker run -it -p 8080:8080 -p 50000:50000 jenkinsci/jenkins:latest

docker build -t jenkins-master .

docker build -t jenkins-slave .

docker-compose -f .\docker-compose.ci.yml up

switch it docker's location
	docker exec -it 049770b976e0 /bin/bash
	cat /var/jenkins_home/secrets/initialAdminPassword

Switch to docker's container as root
	docker exec -u 0 -it 0ece0a3374fe bash

Copy files from docker to local
	docker cp <containerId>:/file/path/within/container /host/path/target

Install MSTestRunner

https://docs.docker.com/engine/reference/commandline/run/

test
