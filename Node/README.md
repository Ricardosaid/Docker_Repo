# Node app & Dockerfile
## acknowledgment
`pablokbs` for the resources and videos
> Note: Visit `https://github.com/pablokbs/peladonerd` for more imformation

## Requirements
1. Docker
2. Command prompt within the Dockerfile exist

## Node version
Alpine, buster, stretch are linux distributions, that used to create the node image

## Dockerizing

Build:

```console
docker build -t node-app .

```
Run:

```console
docker run -dp 3000:3000 node-app

```
> Note: Expose en 3000 port and with a new container id

## Preserve data in a container

```console
docker run -d -p 3000:3000 -v /home/saidleben/Documents/Personal-Dev/DockerSamples/Repo_GitHub_Docker/Docker_Repo/Node/src:/app/src node-app
```
When you has already realized all the changes in the current code, you must create a new image, in shell:

```console
docker build -t node-app:v2 .
```

## Share the image

You can use Docker Hub to publish :

```console
docker tag "image ID" "new tag"
```

```console
docker tag 11111 saidleben/node-app:v2
```
> Note: Is the same image but different id

You can push:

```console
docker push saidleben/node-app:v2
```
