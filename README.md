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


