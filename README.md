# Docker Samples .NET, Python, Go

## Requirements
1. Docker
2. Command prompt within the Dockerfile exist

## Build a Webapi .NET 5.0 image
You can build & run a .NET based container image:

```console
docker build --pull -t webapi:net5 -f Dockerfile .
docker run --rm -it -p 8000:80 webapi
```
Navigate to ``http://localhost:8000` in your web browser

You can use `docker images` to see you've built, if you want see a specific images use `docker images <image name>`
You can also use `grep` to filter searches:

```console
% docker images webapi | grep net 
```

## Build your Go image

### Requirements
1. You have enabled BuildKit on your machine
If you are running Docker on linux, you can enable Buildkit either by using an enviroment or by making Buildkit the default setting
To set the Buildkit environment variable when running the `docker build` command, run : 
```console
$ DOCKER_BUILDKIT=1 docker build .
```

To enable docker BuildKit by default, set daemon configuration in `/etc/docker/daemon.json` feature to true and restart the daemon. If the `daemon.json` file does not exis, create it and the add the following to the file:
```console
{
    "feature" : {
        "buildkit" : true
    }
}
```
and restart the daemon

> Note: Buildkit only supports building Linux containers
2. Go version 1.16 or later

Brief description to install go:

Follow the instructions here `https://go.dev/doc/install`
Commands that can help you :
Delete a directory:
```console
sudo rm -r go
```
In the step two :
Execute in the shell:
```console
cd $HOME
```
and then:
```console
export PATH=$PATH:/usr/local/go/bin
```
### Meet the example application
The sample application is a minimal HTTP server that has only three features:
1. It responds with a text message on request to `/.`
2. It responds with `{"Status":"Ok"}` JSON to the health check request on requests to `/ping`
3. The port it listens on is configurable using the enviroment variable `HTTP_PORT`. The dedault value is `8080`

It has enough basic properties of a REST microservice to be useful for our learning of Docker

### Dockerizing it
```console
docker build --tag docker-gs-ping .
```
> Note: if you don't enable Builkit by default, you need add the tag `DOCKER_BUILDKIT=1 docker build --tag docker-gs-ping .`
If you can work with flags for more readability use:

```console
docker image tag docker-gs-ping:latest docker-gs-ping:v1.0
```
Run our image:
```console
docker run -d -p 8080:8080 --name rest-server docker-gs-ping
```
> Note: `d` = detached (background), `p` = publish 

If you want remove a container:
```console
docker stop "container ID"/"container name"
docker rm "container ID"/"container name"
```
### Helpers
When you `Run` your main.go, the port  `8080` will be used, if you want kill a process running on particular port in linux:

```console
kill -9 $(lsof -t -i:8080)
```

### Multi-stage builds
The main idea is that we use one image to produce some artifacts,which are then placed intro another, much smaller
image, containing only the parts necessary for running the artifacts that we have built



## Build a Scrapping web in python
You can build & run a python based container image:

```console
docker build -t python-scraweb:1.0 .
docker run --ti python-scraweb:1.0
```

> Note: You can see the output in the terminal

## Build a API RESTful in python
For this program, you are going use a virtual enviroment, the structure of this project is:

```
└ FastApi_Sample /
    └ app /
        └ main.py

    └ Dockerfile
    └ .dockerignore
    
```
### Requirements (linux)
1. Create a venv

```console
python3 -m venv env
. env/bin/activate
```
> Note: if you want deactivate the venv, only in the console use `deactivate`

2. Install libraries

```console
pip install fastapi uvicorn
```
### Run the app in the terminal

```console
uvicorn app.main:app
```
### Dockerizer!
You need a requirements for the Dockerfile, so in the terminal:

```console
pip freeze > requirements.txt
```
The new structure become:

```
└ FastApi_Sample /
    └ app /
        └ main.py

    └ Dockerfile
    └ .dockerignore
    └ requirements.txt
    
```

In the terminal:

```console
docker build --pull -t fastapi:1.0 .
docker run -p 80:80 fastapi:1.0 
```
Navigate to ``http://localhost:80` in your web browser

> Note: In production, you can use `docker run -d --name fastapicontainer -p 80:80 fastapi:1.0` you specify background running and the name of the container

### schaulustig

In the therminal :

```console
docker exec -it <container ID> /bin/sh
```
Welcome inside docker container!

### `saidleben`


