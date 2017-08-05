using Microsoft.Extensions.DependencyInjection;
using SnackBar.Domain.Core.Bus;
using SnackBar.Domain.Core.Events;
using SnackBar.Domain.Core.Notifications;
using SnackBar.Domain.Interfaces;
using SnackBar.Domain.Pedidos.Commands;
using SnackBar.Domain.Pedidos.Events;
using SnackBar.Domain.Pedidos.Repository;
using SnackBar.Infra.CrossCutting.Bus;
using SnackBar.Infra.Data.Context;
using SnackBar.Infra.Data.Repository;
using SnackBar.Infra.Data.UoW;

namespace SnackBar.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Domain
            // Commands
            services.AddScoped<IHandler<RealizarPedidoCommand>, PedidoCommandHandler>();

            // Eventos
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<PedidoRealizadoEvent>, PedidoEventHandler>();
            #endregion

            #region Infra
            // Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<SnackBarContext>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            // Bus
            services.AddScoped<IBus, InMemoryBus>();
            #endregion
        }
    }
}
