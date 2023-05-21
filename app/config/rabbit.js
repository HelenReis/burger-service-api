module.exports = {
    host_rabbitmq: process.env.HOST_RABBITMQ,
    host: process.env.HOST,
    port: process.env.PORT,
    username: process.env.USERNAME,
    password: process.env.PASSWORD,
    connection_string: `amqp://${process.env.HOST_RABBITMQ}`,
    cheese_queue: 'cheese_client'
  };
