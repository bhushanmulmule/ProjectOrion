using FluentValidation;

namespace Orion.Application.StoryAppLayer.UseCases.StoryUseCases.UpdateStory
{
    public class UpdateStoryCommandValidator : AbstractValidator<UpdateStoryCommand>
    {
        public UpdateStoryCommandValidator()
        {
            RuleFor(v => v.Text).NotNull().NotEmpty()
                .MaximumLength(300);
        }
    }
}
