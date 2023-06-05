module.exports = {
    host_rabbitmq: process.env.HOST_RABBITMQ,
    host: process.env.HOST,
    port: process.env.PORT,
    username: process.env.USERNAME,
    password: process.env.PASSWORD,
    connection_string: `amqp://rabbitmq`,
    cheese_queue: 'cheese_client',
    steak_queue: 'steak_client',
    bacon_queue: 'bacon_client',
    pickle_queue: 'pickle_client',
    tomato_queue: 'tomato_client',
    lettuce_queue: 'lettuce_client'
  };
