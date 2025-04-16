FROM node:20-alpine as build
WORKDIR /app

COPY ./package*.json ./
RUN npm install --production

COPY . .

RUN npm run build || echo "Build skipped"

FROM nginx:1.25-alpine
COPY ./src /usr/share/nginx/html
EXPOSE 80
