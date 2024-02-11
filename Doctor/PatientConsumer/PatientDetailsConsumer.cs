using Confluent.Kafka;
using DBContext;
using DBContext.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Patient.Persister.Model;
using Patient.Persister.Persister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PatientConsumer
{
    public class PatientDetailsConsumer : BackgroundService
    {
        private readonly IConsumer<Ignore, string> _consumer;
        private readonly ILogger<PatientDetailsConsumer> _logger;
        private readonly PatientDetailsHandler _PatientDetailsHandler;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        //private readonly DoctorDBContext _doctorDBContext;

        public PatientDetailsConsumer(IConfiguration configuration, ILogger<PatientDetailsConsumer> logger,  IServiceScopeFactory _serviceScopeFactory)
        {

            _logger = logger;
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"],
                GroupId = "InventoryConsumerGroup",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
           // _PatientDetailsHandler = patientDetailsHandler;
            this._serviceScopeFactory = _serviceScopeFactory;
            _PatientDetailsHandler = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<PatientDetailsHandler>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe("PostpatientDetails");

            while (!stoppingToken.IsCancellationRequested)
            {
                ProcessKafkaMessage(stoppingToken);
                Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }

            _consumer.Close();
        }
        public void ProcessKafkaMessage(CancellationToken stoppingToken)
        {
            try
            {
                var consumeResult = _consumer.Consume(stoppingToken);
                var message = consumeResult.Message.Value;

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var xService = scope.ServiceProvider.GetService<PatientDetailsHandler>();
                    xService.Insert(message);
                }
                _logger.LogInformation($"Received Patient Details : {message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing Kafka message: {ex.Message}");
            }
        }
    }

}
