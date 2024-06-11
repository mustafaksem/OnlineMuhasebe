using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRLFeatures.Queries
{
    public sealed record GetAllMainRoleAndRLQueryResponse(
        List<MainRoleAndRoleRelationship> MainRoleAndRoleRelationships);
}
