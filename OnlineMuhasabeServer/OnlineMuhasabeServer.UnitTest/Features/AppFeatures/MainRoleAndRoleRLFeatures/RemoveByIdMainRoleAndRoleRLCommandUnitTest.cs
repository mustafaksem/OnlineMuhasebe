using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRLFeatures.Commands.RemoveByIdMainRoleAndRoleRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasabeServer.UnitTest.Features.AppFeatures.MainRoleAndRoleRLFeatures
{
    public sealed class RemoveByIdMainRoleAndRoleRLCommandUnitTest
    {
        private readonly Mock<IMainRoleAndRoleRelationshipService> _serviceMock;

        public RemoveByIdMainRoleAndRoleRLCommandUnitTest()
        {
            _serviceMock = new();
        }

        [Fact]
        public async Task MainRoleAndRoleRelationshipShouldNotBeNull()
        {
            _serviceMock.Setup(s=> 
            s.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(new MainRoleAndRoleRelationship());
        }

        [Fact]
        public async Task RemoveByIdMainRoleAndRoleRLCommandResponseShouldNotBeNull()
        {
            RemoveByIdMainRoleAndRoleRLCommand removeByIdMainRoleAndRoleRLCommand = new(
                Id: "ab89c723-6086-4d67-b2fd-407bfc0b3f2d");
            RemoveByIdMainRoleAndRoleRLCommandHandler handler = new(_serviceMock.Object);

            _serviceMock.Setup(s =>
            s.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(new MainRoleAndRoleRelationship());

            RemoveByIdMainRoleAndRoleRLCommandResponse response = await handler.Handle(removeByIdMainRoleAndRoleRLCommand, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
