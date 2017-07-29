using SnackBar.Domain.Core.Commands;
using System;

namespace SnackBar.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}