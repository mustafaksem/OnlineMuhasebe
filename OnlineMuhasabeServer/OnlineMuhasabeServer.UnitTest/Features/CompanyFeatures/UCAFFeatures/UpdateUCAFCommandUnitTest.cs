using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Command.UpdateUCAF;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.UCAFeatures
{
    public sealed class UpdateUCAFCommandUnitTest
    {
        private readonly Mock<IUCAFService> _ucafService;
        private readonly Mock<IApiService> _apiService;
        private readonly Mock<ILogService> _logService;

        public UpdateUCAFCommandUnitTest()
        {
            _ucafService = new();
            _apiService = new();
            _logService = new();
        }

        [Fact]
        public async Task UniformChartOfAccountShouldNotBeNull()
        {
            _ucafService.Setup(s =>
            s.GetByIdAsync(
                It.IsAny<string>(),
                It.IsAny<string>()))
                .ReturnsAsync(new UniformChartOfAccount());
        }

        [Fact]
        public async Task CheckNewUCAFCodeShouldBeNull()
        {
            string companyId = "a7b84afe-81b0-4a9e-854e-e9568ee521a7";
            string code = "100.01.001";
            UniformChartOfAccount ucaf = await _ucafService.Object.GetByCodeAsync(companyId, code, default);
            ucaf.ShouldBeNull();
        }

        [Fact]
        public async Task UpdateUCAFCommandResponseShouldNotBeNull()
        {
            UpdateUCAFCommand command = new(
                Id: "1590e4a2-42e4-4637-983e-5d163efb6609",
                Code: "100.01.001",
                Name: "MERKEZ KASA",
                Type: "M",
                CompanyId: "585985c0-4576-4d62-ae67-59a6f72ae906");

            await UniformChartOfAccountShouldNotBeNull();

            UpdateUCAFCommandHandler handler = new UpdateUCAFCommandHandler(_ucafService.Object, _logService.Object, _apiService.Object);
            UpdateUCAFCommandResponse response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}