using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SnackBar.Domain.Core.Notifications;
using SnackBar.Domain.Handlers;
using SnackBar.Domain.Interfaces;
using SnackBar.Domain.Pedidos.Commands;
using SnackBar.Domain.Pedidos.Events;
using SnackBar.Domain.Pedidos.Repository;
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
            // Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Commands
            services.AddScoped<INotificationHandler<RealizarPedidoCommand>, PedidoCommandHandler>();

            // Eventos
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<PedidoRealizadoEvent>, PedidoEventHandler>();
            #endregion

            #region Infra
            // Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<SnackBarContext>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            #endregion
        }
    }
}
