using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance.UnitOfWorks;

public sealed class CompanyDbUnitOfWork : ICompanyDbUnitOfWork
{
    private CompanyDbContext _contex;
    public void SetDbContextInstance(DbContext context)
    {
        _contex = (CompanyDbContext)context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        int count = await _contex.SaveChangesAsync(cancellationToken);
        return count;
    }
}
