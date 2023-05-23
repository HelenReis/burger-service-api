FROM rabbitmq:3-management

RUN apt-get update && apt-get install -y netcat

EXPOSE 5672 15672

CMD ["rabbitmq-server"]