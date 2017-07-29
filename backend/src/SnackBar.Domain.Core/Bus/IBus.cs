using SnackBar.Domain.Core.Commands;
using SnackBar.Domain.Core.Events;

namespace SnackBar.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}
