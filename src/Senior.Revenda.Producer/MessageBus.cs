using MassTransit;
using Senior.Revenda.Contract.Producer;
using System;
using System.Threading.Tasks;

namespace Senior.Revenda.Producer
{
    public class MessageBus : IMessageBus
    {
        private readonly IBusControl _bus;

        public MessageBus(IBusControl bus)
        {
            _bus = bus;
        }

        public async Task SendAsync<T>(T message, string nomeFila)
        {
            Uri uri = new Uri($"rabbitmq://localhost/{nomeFila}");
            var endpoint = await _bus.GetSendEndpoint(uri);
            await endpoint.Send(message);
        }
    }
}
