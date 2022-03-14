using Showroom.Domain.Contracts.Repositories;
using Showroom.Persistence.Data;

namespace Showroom.Persistence.Transaction
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private ShowroomDataContext _context;

        public UnitOfWork(ShowroomDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}