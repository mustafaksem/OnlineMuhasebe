using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.CreateMainRoleAndUserRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasabeServer.UnitTest.Features.AppFeatures.MainRoleAndUserRLFeatures
{
    public sealed class CreateMainRoleAndUserRLCommandUnitTest
    {
        private readonly Mock<IMainRoleAndUserRelationshipService> _serviceMock;

        public CreateMainRoleAndUserRLCommandUnitTest()
        {
            _serviceMock = new();
        }
        [Fact]
        public async Task MainRoleAndUserRelationshipShouldNotBeNull()
        {
            MainRoleAndUserRelationship entity=await 
                _serviceMock.Object.GetByUserIdCompanyIdAndMainRoleIdAsync(
                userId: "32c7dff1-307e-46ba-b162-cb2f86e5e5b9",
                companyId: "9525640a-a839-49cb-9611-859c6b5b3177",
                mainRoleId: "38145cfd-5180-4ae9-aea6-b5a234982f69",
                cancellationToken: default);
            entity.ShouldBeNull();
        }

        [Fact]
        public async Task CreateMainRoleAndUserRLCommandResponseShouldNotBeNull()
        {
            CreateMainRoleAndUserRLCommand command = new(
                UserId: "32c7dff1-307e-46ba-b162-cb2f86e5e5b9",
                MainRoleId: "38145cfd-5180-4ae9-aea6-b5a234982f69",
                CompanyId: "9525640a-a839-49cb-9611-859c6b5b3177");
            CreateMainRoleAndUserRLCommandHandler handler = new(_serviceMock.Object);
            CreateMainRoleAndUserRLCommandResponse response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        } 
    }
}
