using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRLFeatures.Commands.CreateMainRoleAndRL
{
    public sealed record CreateMainRoleAndRoleRLCommand(
        string RoleId,
        string MainRoleId) :ICommand<CreateMainRoleAndRoleRLCommandResponse>;
}
