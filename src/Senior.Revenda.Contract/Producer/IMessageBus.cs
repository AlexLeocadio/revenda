using System.Threading.Tasks;

namespace Senior.Revenda.Contract.Producer
{
    public interface IMessageBus
    {
        Task SendAsync<T>(T message, string nomeFila);
    }
}
