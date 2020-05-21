using AvaliacaoTec_APICore.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace AvaliacaoTec_APICore.Data.Repository
{
    public class BaseRepository : IDisposable
    {
        protected EntityContext _context { get; set; }

        public void Dispose()
        {
            if (this._context != null)
            {
                this._context.Dispose();
            }
        }

        protected TransactionScope CreateTransactionScopeWithIsolationLevel(System.Transactions.IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, TimeSpan? timeout = null)
        {
            var opts = new TransactionOptions();
            opts.IsolationLevel = isolationLevel;
            if (timeout == null)
            {
                timeout = new TimeSpan(0, 1, 30);
            }
            opts.Timeout = timeout.Value;
            return new TransactionScope(TransactionScopeOption.Required, opts);
        }
    }
}
