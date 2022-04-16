using FluentValidation;
using LightsOutGame.Services.Business.Commands.PlayerCreate;

namespace LightsOutGame.Services.Business.Commands.Validators
{
    public class PlayerValidator : AbstractValidator<PlayerCreateCommand>
    {
        public PlayerValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Enter your firstname!");
            RuleFor(v => v.Surname).NotEmpty().WithMessage("Enter your lastname!");
            RuleFor(v => v.BoardSize).NotEmpty().WithMessage("Select board size!");
        }
    }
}
