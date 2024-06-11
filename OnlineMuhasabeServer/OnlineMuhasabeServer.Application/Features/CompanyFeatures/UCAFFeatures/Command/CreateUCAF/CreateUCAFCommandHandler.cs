using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Command.CreateUCAF;

public sealed class CreateUCAFCommandHandler : ICommandHandler<CreateUCAFCommand, CreateUCAFCommandResponse>
{
    private readonly IUCAFService _ucafService;

    public CreateUCAFCommandHandler(IUCAFService ucafService)
    {
        _ucafService = ucafService;
    }

    public async Task<CreateUCAFCommandResponse> Handle(CreateUCAFCommand request, CancellationToken cancellationToken)
    {
        UniformChartOfAccount ucaf = await _ucafService.GetByCode(request.Code, cancellationToken);
        if (ucaf != null) throw new Exception("Bu hesap plnı kodu daha önce tanımlanmıştır! ");

        await _ucafService.CreateUCAFAsync(request, cancellationToken);
        return new();
    }
}
