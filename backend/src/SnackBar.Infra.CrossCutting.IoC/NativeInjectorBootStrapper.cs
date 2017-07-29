using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SnackBar.Domain.Core.Bus;
using SnackBar.Domain.Core.Notifications;
using SnackBar.Domain.Interfaces;
using SnackBar.Infra.CrossCutting.Bus;
using SnackBar.Infra.Data.Context;
using SnackBar.Infra.Data.UoW;

namespace SnackBar.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Domain
            // Eventos
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            #endregion

            #region Infra
            // Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<SnackBarContext>();

            // Bus
            services.AddScoped<IBus, InMemoryBus>();
            #endregion
        }
    }
}
