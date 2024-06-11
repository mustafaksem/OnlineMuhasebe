using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Shouldly;

namespace OnlineMuhasabeServer.UnitTest.Features.AppFeatures.RoleFeatures.Commands
{
    public sealed class UpdateRoleCommandUnitTest
    {
        private readonly Mock<IRoleService> _roleServiceMock;

        public UpdateRoleCommandUnitTest()
        {
            _roleServiceMock = new();
        }

        [Fact]
        public async Task AppRoleShouldNotBeNull()
        {
            _ = _roleServiceMock.Setup(
                x=>x.GetById(It.IsAny<string>()))
                .ReturnsAsync(new AppRole());
        }
        [Fact]
        public async Task AppRoleCodeShouldBeUniqe()
        {
            AppRole checkRoleCode=await _roleServiceMock.Object.GetByCode("UCAF.Create");
            checkRoleCode.ShouldBeNull();
        }

        [Fact]
        public async Task UpdateRoleCommandResponseShouldNotBeNull()
        {
            var command = new UpdateRoleCommand(
                Id: "7687dbd3-3cc3-44d5-a689-685bea09deec",
                Code: "UCAF.Create",
                Name: "Hesap planı kayıt ekleme");

            _ = _roleServiceMock.Setup(
               x => x.GetById(It.IsAny<string>()))
               .ReturnsAsync(new AppRole());

            var handler = new UpdateRoleCommandHandler(_roleServiceMock.Object);
            UpdateRoleCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
