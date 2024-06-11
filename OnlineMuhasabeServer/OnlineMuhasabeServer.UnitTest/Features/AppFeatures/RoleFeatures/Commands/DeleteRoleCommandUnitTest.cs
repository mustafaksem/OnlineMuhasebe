using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Shouldly;

namespace OnlineMuhasabeServer.UnitTest.Features.AppFeatures.RoleFeatures.Commands
{
    public sealed class DeleteRoleCommandUnitTest
    {
        private readonly Mock<IRoleService> _roleServiceMock;

        public DeleteRoleCommandUnitTest()
        {
            _roleServiceMock = new();
        }
        [Fact]
        public async Task AppRoleShouldNotBeNull()
        {
            _roleServiceMock.Setup(
                x=>x.GetById(It.IsAny<string>()))
                .ReturnsAsync(new AppRole());
        }
        [Fact]
        public async Task DeleteRoleCommandResponseShouldNotBeNull()
        {
            var command = new DeleteRoleCommand(
                Id: "6eebd692-3332-4c12-bc89-6e96583ba3c4");
            _roleServiceMock.Setup(
                x => x.GetById(It.IsAny<string>()))
                .ReturnsAsync(new AppRole());
            var hamdler = new DeleteRoleCommandHandler(_roleServiceMock.Object);
            DeleteRoleCommandResponse response = await hamdler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();

        }
    }
}
