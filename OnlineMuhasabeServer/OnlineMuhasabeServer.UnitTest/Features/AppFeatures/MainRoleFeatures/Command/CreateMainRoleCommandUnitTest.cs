using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasabeServer.UnitTest.Features.AppFeatures.MainFeatures.Command
{
    public sealed class CreateMainRoleCommandUnitTest
    {
        private readonly Mock<IMainRoleService> _mainRoleService;

        public CreateMainRoleCommandUnitTest()
        {
            _mainRoleService = new();
        }
        [Fact]
        public async Task MainRoleShouldBeNull()
        {
            MainRole mainRole = await _mainRoleService.Object.GetByTitleAndCompanyId(
                title:"Admin",
                companyId:"6eebd692-3332-4c12-bc89-6e96583ba3c4",
                default);
            mainRole.ShouldBeNull();
        }
        [Fact]
        public async Task CreateMainRoleCommandResponseShouldNotBeNull()
        {
            var command = new CreateMainRoleCommand(
                Title: "Admin",
                CompanyId: "6eebd692-3332-4c12-bc89-6e96583ba3c4");
            var handler = new CreateMainRoleCommandHandler(_mainRoleService.Object);
            CreateMainRoleCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
