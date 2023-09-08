using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Core.Entities;
using WarbyApp.Service.Dtos.ColorDtos;

namespace WarbyApp.Service.Dtos.ColorDtos
{
    public class ColorCreateDto
    {
        public string ColorName { get; set; }
        public IFormFile ColorImage { get; set; }
    }
    public class ColorCreateDtoValidator : AbstractValidator<ColorCreateDto>
    {
        public ColorCreateDtoValidator()
        {
            RuleFor(x => x.ColorName)
                .NotEmpty().MaximumLength(25);

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.ColorImage != null)
                {
                    if (x.ColorImage.Length > 2 * 1024 * 1024)
                        context.AddFailure("ImageFile", "Image file must be less or equal that 2MB");

                    if (x.ColorImage.ContentType != "image/png" && x.ColorImage.ContentType != "image/jpeg")
                        context.AddFailure("ImageFile", "Image file must be png,jpg or jpeg");
                }
            });
        }
    }
}
