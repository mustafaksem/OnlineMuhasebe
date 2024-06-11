using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.RemoveByIdMainRoleAndUserRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasabeServer.UnitTest.Features.AppFeatures.MainRoleAndUserRLFeatures
{
    public sealed class RemoveByIdMainRoleAndUserRLCommandUnitTest
    {
        private readonly Mock<IMainRoleAndUserRelationshipService> _serviceMock;

        public RemoveByIdMainRoleAndUserRLCommandUnitTest()
        {
            _serviceMock = new();
        }
        [Fact]
        public async Task RemoveByIdMainRoleAndUserRelationshipShouldNotBeNull()
        {
            _serviceMock.Setup(
                x=>x.GetByIdAsync(It.IsAny<string>(),false)).
                ReturnsAsync(new MainRoleAndUserRelationship());
        }

        [Fact]
        public async Task RemoveByIdMainRoleAndUserRelationshipCommandResponseShouldNotBeNull()
        {
            RemoveByIdMainRoleAndUserRLCommand command = new(
                Id: "");

            RemoveByIdMainRoleAndUserRLCommandHandler handler = new(_serviceMock.Object);

            _serviceMock.Setup(
                x => x.GetByIdAsync(It.IsAny<string>(), false)).
                ReturnsAsync(new MainRoleAndUserRelationship());

            RemoveByIdMainRoleAndUserRLCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
