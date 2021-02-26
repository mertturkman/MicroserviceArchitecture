using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Abstractions.Query
{
    public interface IQueryDispatcher
    {
        Task<TResult> HandleAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}
