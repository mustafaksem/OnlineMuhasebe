using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasabeServer.UnitTest.Features.AppFeatures.MainRoleFeatures.Command
{
    public sealed class UpdateMainRoleCommandUnitTest
    {
        private readonly Mock<IMainRoleService> _mainRoleService;

        public UpdateMainRoleCommandUnitTest()
        {
            _mainRoleService = new();
        }
        [Fact]
        public async Task MainRoleShouldNotBeNull()
        {
            _mainRoleService.Setup(x=>x.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(new MainRole());
        }
        [Fact]
        public async Task UpdateMainRoleCommandResponseShouldNotBeNull()
        {
            var command = new UpdateMainRoleCommand(
                Id: "6eebd692-3332-4c12-bc89-6e96583ba3c4", 
                Title: "Admin");
            var handler = new UpdateMainRoleCommandHandler(_mainRoleService.Object);

            _mainRoleService.Setup(x => x.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(new MainRole());

            UpdateMainRoleCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
