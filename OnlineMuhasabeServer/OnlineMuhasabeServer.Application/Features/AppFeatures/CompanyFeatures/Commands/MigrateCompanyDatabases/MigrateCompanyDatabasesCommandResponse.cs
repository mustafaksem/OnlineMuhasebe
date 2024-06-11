namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public sealed record MigrateCompanyDatabasesCommandResponse(
        string Message = "Şirketlerin database bilgileri migrate edildi!");
}
