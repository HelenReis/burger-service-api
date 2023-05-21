const express = require('express');
const app = express();
const http = require('http');
const server = http.createServer(app);
const { Server } = require("socket.io");
const io = new Server(server);
const amqp = require('amqplib');
const rabbitmqConfig = require('./config/rabbit');

io.on('connection', (socket) => {
  socket.on('chat message', msg => {
    io.emit('chat message', msg);
  });
});

app.use(express.static('public', {
  setHeaders: (res, path) => {
    if (path.endsWith('.css')) {
      res.setHeader('Content-Type', 'text/css');
    } else if (path.endsWith('.js')) {
      res.setHeader('Content-Type', 'text/javascript');
    }
  },
}));

app.get('/', (req, res) => {
  res.sendFile(__dirname + './public/index.html');
});

server.listen(rabbitmqConfig.port, () => {
  console.log(`App is running on http://localhost:${rabbitmqConfig.port}`);
});

const connect = async () => {
  try {
    const connection = await amqp.connect(rabbitmqConfig.connection_string);
    const channel = await connection.createChannel();
    
    channel.consume(rabbitmqConfig.cheese_queue, (message) => {
      io.emit('cheese');
    });
  } catch (error) {
    console.error('Error:', error);
  }
};

connect();



