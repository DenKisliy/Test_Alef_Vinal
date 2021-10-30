using BusinessObject.Models;
using FluentValidation;

namespace BusinessLogic
{
    class CreateProductValidator : AbstractValidator<CreateProductModel>
    {
        public CreateProductValidator()
        {
            var msg = "Ошибка в поле {PropertyName}: значение {PropertyValue}";

            RuleFor(c => c.Value)
                .NotEmpty().WithMessage(msg)
                .Length(3).WithMessage("Длина значения должна быть {Length}. Текущая длина: {TotalLength}");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(msg)
                .Length(3, 50).WithMessage("Длина имени должна быть от {MinLength} до {MaxLength}. Текущая длина: {TotalLength}");
        }
    }
}
