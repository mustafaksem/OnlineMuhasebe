using OnlineMuhasebeServer.Application.Messaging;
using System.Windows.Input;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateAllRoles
{
    public sealed record CreateStaticRolesCommand() :
        ICommand<CreateStaticRolesCommandResponse>;
}
