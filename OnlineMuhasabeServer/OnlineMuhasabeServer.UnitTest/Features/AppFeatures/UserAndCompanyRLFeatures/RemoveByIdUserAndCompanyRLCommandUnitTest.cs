using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.RemoveByIdUserAndCompanyRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using Shouldly;

namespace OnlineMuhasabeServer.UnitTest.Features.AppFeatures.UserAndCompanyRLFeatures
{
    public sealed class RemoveByIdUserAndCompanyRLCommandUnitTest
    {
        private readonly Mock<IUserAndCompanyRelationshipService> _serviceMock;

        public RemoveByIdUserAndCompanyRLCommandUnitTest()
        {
            _serviceMock = new();
        }

        [Fact]
        public async Task RemoveByIdUserAndCompanyRLCommandResponseShouldNotBeNull()
        {
            RemoveByIdUserAndCompanyRLCommand command = new(
                Id: "6a1214fa-9759-4fce-89ba-cd75d51692b4");

            RemoveByIdUserAndCompanyRLCommandHandler handler = new(_serviceMock.Object);
            RemoveByIdUserAndCompanyRLCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
