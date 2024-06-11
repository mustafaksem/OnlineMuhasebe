using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.CreateMainRoleAndUserRL
{
    public sealed class CreateMainRoleAndUserRLCommandValidator :AbstractValidator<CreateMainRoleAndUserRLCommand>
    {
        public CreateMainRoleAndUserRLCommandValidator()
        {
            RuleFor(p=>p.UserId).NotEmpty().WithMessage("Kullanıcı seçilmmelidir.");
            RuleFor(p=>p.UserId).NotNull().WithMessage("Kullanıcı seçilmmelidir.");
            RuleFor(p=>p.CompanyId).NotEmpty().WithMessage("Şirket seçilmmelidir.");
            RuleFor(p=>p.CompanyId).NotNull().WithMessage("Şirket seçilmmelidir.");
            RuleFor(p=>p.MainRoleId).NotEmpty().WithMessage("Rol seçilmmelidir.");
            RuleFor(p=>p.MainRoleId).NotNull().WithMessage("Rol seçilmmelidir.");
        }
    }
}
