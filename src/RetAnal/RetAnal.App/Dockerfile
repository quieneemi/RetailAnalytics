FROM node:alpine as app-build-env
WORKDIR /app
COPY . .
RUN npm install && npm run ng build

# Build runtime image
FROM nginx:alpine
WORKDIR /usr/share/nginx/html
RUN rm -rf ./*
COPY --from=app-build-env /app/dist/angularapp .
EXPOSE 80
