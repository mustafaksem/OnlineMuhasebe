using Newtonsoft.Json;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Dtos;
using RabbitMQ.Client;
using System.Text;

namespace OnlineMuhasebeServer.Infrastructure.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        public void SendeQueue(ReportDto reportDto)
        {
            var factory = new ConnectionFactory();
            factory.Uri=new Uri("amqps://abmpaitu:F6A4VNnjV85TlKDNj5oMc9D4f9x_utfE@chimpanzee.rmq.cloudamqp.com/abmpaitu");

            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();
            channel.QueueDeclare("Reports", true, false, false);
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(reportDto));
            channel.BasicPublish(string.Empty, "Reports", null, body);
        }
    }
}
