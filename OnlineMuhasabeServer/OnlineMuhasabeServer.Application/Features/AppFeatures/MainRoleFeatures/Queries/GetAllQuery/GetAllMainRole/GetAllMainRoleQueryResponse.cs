using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Queries.GetAllQuery.GetAllMainRole
{
    public sealed record GetAllMainRoleQueryResponse(
        IList<MainRole> mainRoles);
}
