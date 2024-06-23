using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.ReportFeatures
{
    public sealed class RequestReportCommandUnitTest
    {
        private readonly Mock<IReportService> _reportService;
        public RequestReportCommandUnitTest()
        {
            _reportService = new();
        }

        [Fact]
        public async Task RequestReportCommandResponseShouldNotBeNull()
        {
            RequestReportCommand command = new(
                Name: "Hesap Planı",
                CompanyId: "");

            RequestReportCommandHandler handler = new RequestReportCommandHandler(_reportService.Object);

            RequestReportCommandResponse response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}