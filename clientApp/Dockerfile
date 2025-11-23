# Stage 1: Build Vue with Bun
FROM oven/bun:1 AS build
WORKDIR /app

COPY package.json ./
RUN bun install

COPY . .

RUN bun run build

# Stage 2: Serve with Nginx
FROM nginx:alpine

RUN rm /etc/nginx/conf.d/default.conf

COPY --from=build /app/dist /usr/share/nginx/html

COPY nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]