using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Abstractions.Query
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> QueryAsync(TQuery query);
    }
}
