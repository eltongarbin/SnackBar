using SnackBar.Domain.Core.Commands;
using SnackBar.Domain.Interfaces;
using SnackBar.Infra.Data.Context;

namespace SnackBar.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SnackBarContext _context;

        public UnitOfWork(SnackBarContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}