using OnlineMuhasebeServer.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole
{
    public sealed record UpdateMainRoleCommand(
        string Id,
        string Title):ICommand<UpdateMainRoleCommandResponse>;
}
