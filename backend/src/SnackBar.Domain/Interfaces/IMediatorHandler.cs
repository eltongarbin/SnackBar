using SnackBar.Domain.Core.Commands;
using SnackBar.Domain.Core.Events;
using System.Threading.Tasks;

namespace SnackBar.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task EnviarComando<T>(T theCommand) where T : Command;
        Task PublicarEvento<T>(T theEvent) where T : Event;
    }
}
