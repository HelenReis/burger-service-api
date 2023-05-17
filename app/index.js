const port = 3000;
const express = require('express');
const app = express();
const http = require('http');
const server = http.createServer(app);
const { Server } = require("socket.io");
const io = new Server(server);
const amqp = require('amqplib');

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

server.listen(port, () => {
  console.log(`App is running on http://localhost:${port}`);
});

const connect = async () => {
  try {
    const connection = await amqp.connect('amqp://guest:guest@localhost:5672');
    const channel = await connection.createChannel();
    const queue = 'cheese_client';
    
    channel.consume(queue, (message) => {
      io.emit('shrink', 'oi');
      if (message !== null) {
        console.log('Received message:', message.content.toString());
        
        // Acknowledge the message
        channel.ack(message);
      }
    });
  } catch (error) {
    console.error('Error:', error);
  }
};

connect();



