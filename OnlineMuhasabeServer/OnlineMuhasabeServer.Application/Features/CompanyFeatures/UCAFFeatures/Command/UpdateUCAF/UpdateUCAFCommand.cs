using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Command.UpdateUCAF
{
    public sealed record UpdateUCAFCommand(
        string Id,
        string Code,
        string Name,
        string Type,
        string CompanyId) :ICommand<UpdateUCAFCommandResponse>;
}
