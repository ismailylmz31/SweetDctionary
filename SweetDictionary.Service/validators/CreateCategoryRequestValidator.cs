using FluentValidation;
using SweetDictionary.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.validators
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequestDto>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori adı boş olamaz")
                .Length(2, 50).WithMessage("Kategori adı 2 ile 50 karakter arasında olmalıdır");
        }
    }
}
