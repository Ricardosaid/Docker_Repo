FROM node:12.22.1-alpine3.11

#RUN apk add --no-cache python2 build-base
WORKDIR /app
COPY . .
# Compile our code
RUN yarn install --production
# run the node command in the index.js file
CMD ["node", "/app/src/index.js"]
