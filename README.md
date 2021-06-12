# Simple sender and consumer using Mass Transit RabbitMQ

The requests and responses are shared using Project Reference in both the sender and the consumer.

The sender API comprises of a request client and formulates a request and sends it to the exchange auto created by MassTransit using the AMQP 0-9-1 protocol.

The exchange created by MassTransit using Fanout exchange type by default.

The exchange is bound to the queue which is represented by a receiving endpoint in the consumer code. The consumer exposes a [`Consume`](./src/Consumer/Consumers/CommentsConsumer.cs#L18-L26) method which acts as an entry point for the consumer handler.

The consumer then calls the [`JSONPlaceholder comments API`](https://jsonplaceholder.typicode.com/comments) to fetch the response and send back to the sender.