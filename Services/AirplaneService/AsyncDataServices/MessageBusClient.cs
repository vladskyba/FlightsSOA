using AirportService.DataTransfer;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;

namespace Airport.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;
        
        private readonly IConnection _connection;
        
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var port = _configuration["RABBITMQ_PORT"] ?? "5672";

            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RABBITMQ_HOST"] ?? "localhost",
                Port = int.Parse(port)
            };

            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare("trigger", ExchangeType.Fanout);

                Console.WriteLine($"Connected to RabbitMQ");
            }
            catch(Exception exception)
            {
                Console.WriteLine($"Could not connect to the RabbitMQ: {exception.Message}");
            }
        }

        public void RegisterService() 
        {
            var port = _configuration["SERVICE_PORT"] ?? "1";

            var serviceSettings = new ServiceSettings
            {
                Name = _configuration["SERVICE_NAME"],
                Port = int.Parse(port),
                Event = "airplane-service.register"
            };

            var message = JsonSerializer.Serialize(serviceSettings);

            if (_connection.IsOpen)
            {
                SendMessage(message);
            }
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "trigger", 
                    routingKey: "",
                    basicProperties: null,
                    body: body);
        }

        public void Dispose()
        {
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }
    }
}
