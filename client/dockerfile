FROM node:latest
WORKDIR /app

COPY ["package.json", "package-lock.json", "/app/"]

RUN npm install --omit=dev

COPY . /app

RUN npm run build

RUN npm i -g serve

ENTRYPOINT ["serve", "-s", "/app/build"]