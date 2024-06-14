using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Queries.GetAllUCAF;
using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Queries.GetAll
{
    public sealed record GetAllUCAFQuery(string CompanyId): IQuery<GetAllUCAFQueryResponse>;
}
