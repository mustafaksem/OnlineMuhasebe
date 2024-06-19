using Azure.Core;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Dtos;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.ReportRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance.Services.CompanyServices;

public class ReportService : IReportService
{
    private CompanyDbContext _context;
    private readonly IContextService _contextService;
    private readonly IReportCommandRepository _commandRepository;
    private readonly IReportQueryRepository _queryRepository;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IRabbitMQService _rabbitMQService;
    public ReportService(IReportQueryRepository queryRepository, IReportCommandRepository commandRepository, IContextService contextService, ICompanyDbUnitOfWork unitOfWork, IRabbitMQService rabbitMQService)
    {
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
        _contextService = contextService;
        _unitOfWork = unitOfWork;
        _rabbitMQService = rabbitMQService;
    }


    public async Task<PaginationResult<Report>> GetAllReportsByCompanyID(string companyId, int pageNumber = 1, int pageSize = 5)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().OrderByDescending(p=>p.CreatedDate).ToPagedListAsync(pageNumber,pageSize);
        return result;
    }

    public async Task Request(RequestReportCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);


        Report report = new()
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            Status = false
        };

        await _commandRepository.AddAsync(report, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        SendQueue(report, request.CompanyId);
    }

    public void SendQueue(Report report,string companyId)
    {
        ReportDto reportDto = new()
        {
            Id = report.Id,
            Name = report.Name,
            CompanyId = companyId
        };

        _rabbitMQService.SendeQueue(reportDto);
    }
}
