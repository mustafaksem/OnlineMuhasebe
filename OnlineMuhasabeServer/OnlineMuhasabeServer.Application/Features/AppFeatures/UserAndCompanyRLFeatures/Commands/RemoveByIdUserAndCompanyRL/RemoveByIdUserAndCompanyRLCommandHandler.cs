using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.RemoveByIdUserAndCompanyRL
{
    public sealed class RemoveByIdUserAndCompanyRLCommandHandler : ICommandHandler<RemoveByIdUserAndCompanyRLCommand, RemoveByIdUserAndCompanyRLCommandResponse>
    {
        private readonly IUserAndCompanyRelationshipService _service;

        public RemoveByIdUserAndCompanyRLCommandHandler(IUserAndCompanyRelationshipService service)
        {
            _service = service;
        }

        public async Task<RemoveByIdUserAndCompanyRLCommandResponse> Handle(RemoveByIdUserAndCompanyRLCommand request, CancellationToken cancellationToken)
        {
            await _service.RemoveByIdAsync(request.Id);
            return new();
        }
    }
}
