using BusinessObject.Models;
using FluentValidation;

namespace BusinessLogic
{
    class UpdateProductValidator : AbstractValidator<UpdateProductModel>
    {
        public UpdateProductValidator()
        {
            var msg = "Ошибка в поле {PropertyName}: значение {PropertyValue}";

            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage(msg);

            RuleFor(c => c.Value)
                .NotEmpty().WithMessage(msg)
                .Length(3).WithMessage("Длина значения должна быть {Length}. Текущая длина: {TotalLength}");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(msg)
                .Length(3, 50).WithMessage("Длина имени должна быть от {MinLength} до {MaxLength}. Текущая длина: {TotalLength}");
        }
    }
}
