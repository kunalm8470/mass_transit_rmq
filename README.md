# Simple sender and consumer using Mass Transit RabbitMQ

Pre-requisites -<br/>
Spin up a local RabbitMQ container with management console
```shell
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

The requests and responses are shared using Project Reference in both the sender and the consumer.

The sender API comprises of a request client and formulates a request and sends it to the exchange auto created by MassTransit using the AMQP 0-9-1 protocol.

The exchange created by MassTransit is using [`Fanout exchange type`](https://lostechies.com/derekgreer/2012/03/28/rabbitmq-for-windows-exchange-types/#fanout-exchanges) by default.

The exchange is bound to the queue which is represented by a receiving endpoint in the consumer code. The consumer exposes a [`Consume`](./src/Consumer/Consumers/CommentsConsumer.cs#L18-L26) method which acts as an entry point for the consumer handler.

The consumer then calls the [`JSONPlaceholder comments API`](https://jsonplaceholder.typicode.com/comments) to fetch the response and send back to the sender.