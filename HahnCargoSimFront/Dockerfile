# Stage 1: Build the Angular application
FROM node:20 as build

WORKDIR /app

COPY package*.json ./

RUN npm install

COPY . .

RUN npm run build --prod

# Stage 2: Serve the Angular application with a lightweight web server
FROM nginx:alpine

COPY --from=build /app/dist/hahn-cargo-sim-front/browser /usr/share/nginx/html


EXPOSE 80

