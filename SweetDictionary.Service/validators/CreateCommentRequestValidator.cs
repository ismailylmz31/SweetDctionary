using FluentValidation;
using SweetDictionary.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.validators
{
    public class CreateCommentRequestValidator : AbstractValidator<CreateCommentRequestDto>
    {
        public CreateCommentRequestValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("Yorum boş olamaz");

            RuleFor(x => x.AuthorId)
                .GreaterThan(0).WithMessage("Geçerli bir yazar ID giriniz");
        }
    }
}
