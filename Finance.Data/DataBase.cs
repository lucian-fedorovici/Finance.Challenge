using Finance.Entities.Interfaces;
using Finance.Shared.Common;
using System;
using System.Data.Entity;
using System.Linq;

namespace Finance.Data
{
    public class DataBase : IDisposable
    {
        private bool _isDisposed;

        private FinanceEntities _context;
        protected FinanceEntities Context
        {
            get
            {
                try
                {
                    // TODO: Fix this issue properly, this is here because using statements will dispose of the DB context meaning repeated use will fail catastrophically
                    var connectionTest = _context.Database.Connection;
                }
                catch
                {
                    _context = new FinanceEntities();
                }

                return _context;
            }
        }

        public DataBase()
        {
            _context = new FinanceEntities();
        }

        public DataBase(FinanceEntities context)
        {
            _context = context;
            _context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public int SaveChanges(RequestContext context)
        {
            foreach (var entry in _context.ChangeTracker.Entries<IAuditable>())
            {
                if (entry.State != EntityState.Unchanged)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.CreatedBy = context.UserId;
                        entry.Entity.CreatedOn = DateTime.Now;
                        entry.Entity.UpdatedBy = context.UserId;
                        entry.Entity.UpdatedOn = DateTime.Now;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entry.Entity.UpdatedBy = context.UserId;
                        entry.Entity.UpdatedOn = DateTime.Now;
                    }
                }
            }

            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    _context.Dispose();
                }

                _isDisposed = true;
            }
        }
    }
}
