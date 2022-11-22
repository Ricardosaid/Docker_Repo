FROM golang:1.16-alpine
WORKDIR /app
#The copy command takes two parameters, the first parameter tells docker what files you want to copy into the image. The last
#parameter tells docker where you want that file to be copied to
COPY go.mod ./
COPY go.sum ./

RUN go mod download
#At this point, we have an image that is based on Go enviroment version 1.16 and we have installed our dependencies
#The next step, we need to copy or source code into the image
COPY *.go ./

RUN go build -o /docker-gs-ping 
#The result of that command (code up) will be a static application binary named docker-gs-ping and located in the root of the
#filesystem of the image that we are building
# We could have put the binary into any other place we desire inside that image, the root directory
# has no special meaning in this regard. Itś just convenient to use it to keep the file paths short 
# for improved readability
EXPOSE 8080

CMD ["/docker-gs-ping" ] 
#Tell docker what command to execute when our image is used to start a container