using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Command.CreateUCAF
{
    public sealed class CreateUCAFCommandValidator :AbstractValidator<CreateUCAFCommand>
    {
        public CreateUCAFCommandValidator() 
        {
            RuleFor(p => p.Code).NotEmpty().WithMessage("Hesap planı Code bilgisi boş olamaz.");
            RuleFor(p => p.Code).NotNull().WithMessage("Hesap planı Code bilgisi boş olamaz.");
            //RuleFor(p => p.Code).MinimumLength(4).WithMessage("Hesap planı Code bilgisi en az 4 karakter olmalıdır.");
            RuleFor(p => p.Name).NotNull().WithMessage("Hesap planı adı boş olamaz.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Hesap planı adı boş olamaz.");
            RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket bilgisi boş olamaz.");
            RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Hesap planı adı boş olamaz.");

            RuleFor(p => p.Type).NotEmpty().WithMessage("Hesap planı tipi adı boş olamaz.");
            RuleFor(p => p.Type).NotNull().WithMessage("Hesap planı tipi adı boş olamaz.");
            RuleFor(p => p.Type).MaximumLength(1).WithMessage("Hesap planı tipi 1 karakterden oluşmalıdır.");

        }
    }
}
