using OnlineMuhasebeServer.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.AppDbContext;

public interface IAppQueryRepository<T> :
    IQueryGenericRepository<T>,
    IRepository<T>
    where T : Entity
{
}
