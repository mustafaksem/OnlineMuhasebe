using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateComapany
{
    public sealed record CreateCompanyCommand (
        string Name,
        string ServerName,
        string DatabaseName,
        string UserId,
        string Password):ICommand<CreateCompanyCommandResponse>;
}
