using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Dtos;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.LogFeatures.Queries.GetLogsByTableName;

public sealed record GetLogsByTableNameQueryResponse(
   PaginationResult<LogDto>Data );
