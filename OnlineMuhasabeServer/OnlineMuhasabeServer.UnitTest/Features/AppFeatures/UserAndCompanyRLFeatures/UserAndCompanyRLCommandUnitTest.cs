using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.CreateUserAndCompanyRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasabeServer.UnitTest.Features.AppFeatures.UserAndCompanyRLFeatures
{
    public sealed class UserAndCompanyRLCommandUnitTest
    {
        private readonly Mock<IUserAndCompanyRelationshipService> _serviceMock;

        public UserAndCompanyRLCommandUnitTest()
        {
            _serviceMock =new();
        }

        [Fact]
        public async Task UserAndCompanyRelationshipShouldNotBeNull()
        {
            UserAndCompanyRelationship userAndCompanyRelationshipService= await _serviceMock.Object.GetByUserIdAndCompanyId(
                    userId: "7060fe36-8d45-4e54-8188-49d4371b2544",
                    companyId: "ef97c725-9d8f-489e-a103-c5607d135728",
                    cancellationToken:default);

            userAndCompanyRelationshipService.ShouldBeNull();
        }

        [Fact]
        public async Task CreateUserAndCompanyRLCommandResponseShouldNotBeNull()
        {
            CreateUserAndCompanyRLCommand command = new(
                AppUserId: "7060fe36-8d45-4e54-8188-49d4371b2544",
                CompanyId: "ef97c725-9d8f-489e-a103-c5607d135728");
            CreateUserAndCompanyRLCommandHandler handler = new(_serviceMock.Object);
            CreateUserAndCompanyRLCommandResponse response = await handler.Handle(command,
                default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeNull();
        }
    }
}
